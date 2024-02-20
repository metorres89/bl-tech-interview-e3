using BlTechInterviewE3.Business.Domain;

namespace BlTechInterviewE3.Data.Mapper;

public class BookDataMapper : IDataMapper<Book> {
    public async Task<IEnumerable<Book>> GetAll() {
        throw new NotImplementedException();
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