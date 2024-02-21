using BlTechInterviewE3.Business.Domain;
using BlTechInterviewE3.Business.Service.Contract;
using BlTechInterviewE3.Business.Utils;

namespace BlTechInterviewE3.Business.Service;

public class BookService : IBookService {
    private IDataMapper<Book> _bookDataMapper;

    public BookService(IDataMapper<Book> bookDataMapper) {
        this._bookDataMapper = bookDataMapper ?? throw new ArgumentNullException("Book data mapper is null");
    }

    public async Task<IEnumerable<Book>> GetAll() {
        IEnumerable<Book> books = await this._bookDataMapper.GetAll();
        return books;
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