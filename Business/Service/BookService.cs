using BlTechInterviewE3.Business.Domain;
using BlTechInterviewE3.Business.Service.Contract;
using BlTechInterviewE3.Business.Utils;

namespace BlTechInterviewE3.Business.Service;

public class BookService : IBookService {
    private IDataMapper<Book> _bookDataMapper;

    public BookService(IDataMapper<Book> bookDataMapper) {
        _bookDataMapper = bookDataMapper ?? throw new ArgumentNullException("Book data mapper is null");
    }

    public async Task<IEnumerable<Book>> GetAll() {
        IEnumerable<Book> books = await _bookDataMapper.GetAll();
        return books;
    }

    public async Task<Book> GetById(int id) {
        Book book = await _bookDataMapper.GetById(id);
        return book;
    }

    public async Task<Book> Create(Book book) {
        book = await _bookDataMapper.Create(book);
        return book;
    }

    public async Task<Book> Update(Book book) {
        if(book.Id == 0)
            throw new ArgumentException("Book has invalid ID");

        book = await _bookDataMapper.Update(book.Id, book);

        return book;
    }

    public async Task<Book> Patch(Book book) {
        if(book.Id == 0)
            throw new ArgumentException("Book has invalid ID");

        Book bookToPatch = await _bookDataMapper.GetById(book.Id);

        if(bookToPatch == null)
            throw new InvalidOperationException($"There is no book with id: {book.Id}. Patch operation can't be completed.");

        if(book.Title != null && book.Title != bookToPatch.Title) bookToPatch.Title = book.Title;
        if(book.ISBN != null && book.ISBN != bookToPatch.ISBN) bookToPatch.ISBN = book.ISBN;

        book = await _bookDataMapper.Update(bookToPatch.Id, bookToPatch);

        return book;
    }

    public async Task<bool> Delete(Book book) {
        if(book.Id == 0)
            throw new ArgumentException("Book has invalid ID");

        bool deleteStatus = await _bookDataMapper.Delete(book.Id);
        return deleteStatus;
    }
}