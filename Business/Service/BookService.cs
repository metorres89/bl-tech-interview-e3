using BlTechInterviewE3.Business.Domain;
using BlTechInterviewE3.Business.Service.Contract;

namespace BlTechInterviewE3.Business.Service;

public class BookService : IBookService {
    public async Task<IEnumerable<Book>> GetAll() {
        throw new NotImplementedException("Method not implemented!");
    }

    public async Task<Book> GetById(int id) {
        throw new NotImplementedException("Method not implemented!");
    }

    public async Task<Book> Create(Book book) {
        throw new NotImplementedException("Method not implemented!");
    }

    public async Task<Book> Update(Book book) {
        throw new NotImplementedException("Method not implemented!");
    }

    public async Task<Book> Patch(Book book) {
        throw new NotImplementedException("Method not implemented!");
    }
}