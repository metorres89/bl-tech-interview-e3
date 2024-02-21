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
                    Id = (int) reader["id"],
                    Title = (string) reader["title"],
                    ISBN = (string) reader["isbn"]
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
        throw new NotImplementedException();
    }

    public async Task<Book> Create(Book entity) {
        throw new NotImplementedException();
    }

    public async Task<Book> Update(int id, Book entity) {
        throw new NotImplementedException();
    }

    public async Task<bool> Delete(int id) {
        throw new NotImplementedException();
    }
}