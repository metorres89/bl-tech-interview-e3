using BlTechInterviewE3.Business.Domain;
using Npgsql;

namespace BlTechInterviewE3.Data.Mapper;

public class BookDataMapper : IDataMapper<Book> {
    private string ConnectionString = "Host=localhost;Port=5432;Username=postgres;Password=password2023;Database=bl-ti;";

    private string TableName = "book";

    private IList<Book> GetCollection(NpgsqlDataReader reader) {
        IList<Book> books = new List<Book>();
        while (reader.Read())
        {
            // Process the results
            //Console.WriteLine(reader["ColumnName"]);

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

        using (NpgsqlConnection connection = new NpgsqlConnection(this.ConnectionString)) {
            
            await connection.OpenAsync();

            using (NpgsqlCommand command = connection.CreateCommand()) {
                command.CommandText = $"SELECT * FROM {this.TableName}";

                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync()) {
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