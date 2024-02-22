using BlTechInterviewE3.Business.Domain;
using BlTechInterviewE3.Business.Utils;
using System.Data;
using System.Data.Common;
using BlTechInterviewE3.Data.Utils;

namespace BlTechInterviewE3.Data.Mapper;

public class BookDataMapper : IDataMapper<Book> {
    private IDbConnectionFactory _dbConnectionFactory;

    private string TableName = "book";

    public BookDataMapper(IDbConnectionFactory dbConnectionFactory) {
        _dbConnectionFactory = dbConnectionFactory;
    }

    private IList<Book> GetCollection(DbDataReader reader) {
        IList<Book> books = new List<Book>();
        while (reader.Read())
        {
            books.Add(
                new Book {
                    Id = reader.IsDBNull(reader.GetOrdinal("id")) ? 0 : (int)reader["id"],
                    Title = reader.IsDBNull(reader.GetOrdinal("title")) ? null : (string)reader["title"],
                    Author = reader.IsDBNull(reader.GetOrdinal("author")) ? null : (string)reader["author"],
                    ISBN = reader.IsDBNull(reader.GetOrdinal("isbn")) ? null : (string)reader["isbn"],
                    CreateDate = reader.IsDBNull(reader.GetOrdinal("create_date")) ? DateTime.MinValue : (DateTime)reader["create_date"],
                    CreateUser = reader.IsDBNull(reader.GetOrdinal("create_user")) ? null : (string)reader["create_user"],
                    UpdateDate = reader.IsDBNull(reader.GetOrdinal("update_date")) ? (DateTime?)null : (DateTime?)reader["update_date"],
                    UpdateUser = reader.IsDBNull(reader.GetOrdinal("update_user")) ? null : (string)reader["update_user"]
                }
            );
        }
        return books;
    }

    public async Task<IEnumerable<Book>> GetAll() {

        IEnumerable<Book> books;

        using (DbConnection connection = _dbConnectionFactory.GetConnection()) {
            
            await connection.OpenAsync();

            using (DbCommand command = connection.CreateCommand()) {
                command.CommandText = $"SELECT * FROM {this.TableName}";

                using (DbDataReader reader = await command.ExecuteReaderAsync()) {
                    books = this.GetCollection(reader);
                    reader.Close();
                }        
            }
        }

        return books;
    }

    public async Task<Book> GetById(int id) {
        using (DbConnection connection = _dbConnectionFactory.GetConnection())
        {
            await connection.OpenAsync();

            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM {TableName} WHERE id = @id";
                command.AddParameterWithValue("id", id);

                using (DbDataReader reader = await command.ExecuteReaderAsync())
                {
                    return GetCollection(reader).FirstOrDefault();
                }
            }
        }
    }

    public async Task<Book> Create(Book entity) {
        using (DbConnection connection = _dbConnectionFactory.GetConnection())
        {
            await connection.OpenAsync();

            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = $@"
                    INSERT INTO {TableName} (title, author, isbn, create_date, create_user)
                    VALUES (@title, @author, @isbn, @create_date, @create_user)
                    RETURNING *";

                command.AddParameterWithValue("title", entity.Title);
                command.AddParameterWithValue("author", entity.Author);
                command.AddParameterWithValue("isbn", entity.ISBN);
                command.AddParameterWithValue("create_date", entity.CreateDate);
                command.AddParameterWithValue("create_user", entity.CreateUser);

                using (DbDataReader reader = await command.ExecuteReaderAsync())
                {
                    return GetCollection(reader).FirstOrDefault();
                }
            }
        }
    }

    public async Task<Book> Update(int id, Book entity) {
        using (DbConnection connection = _dbConnectionFactory.GetConnection())
        {
            await connection.OpenAsync();

            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = $@"
                    UPDATE {TableName}
                    SET 
                        title = @title, 
                        author = @author, 
                        isbn = @isbn, 
                        update_date = @update_date, 
                        update_user = @update_user
                    WHERE id = @id
                    RETURNING *";

                command.AddParameterWithValue("id", id);
                command.AddParameterWithValue("title", entity.Title);
                command.AddParameterWithValue("author", entity.Author);
                command.AddParameterWithValue("isbn", entity.ISBN);
                command.AddParameterWithValue("update_date", entity.UpdateDate);
                command.AddParameterWithValue("update_user", entity.UpdateUser);

                using (DbDataReader reader = await command.ExecuteReaderAsync())
                {
                    return GetCollection(reader).FirstOrDefault();
                }
            }
        }
    }

    public async Task<bool> Delete(int id) {
        using (DbConnection connection = _dbConnectionFactory.GetConnection())
        {
            await connection.OpenAsync();

            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = $"DELETE FROM {TableName} WHERE id = @id";
                command.AddParameterWithValue("id", id);

                int rowsAffected = await command.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }
    }
}