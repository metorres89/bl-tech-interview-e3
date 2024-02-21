using BlTechInterviewE3.Business.Domain;

namespace BlTechInterviewE3.Business.Service.Contract;

public interface IBookService {
    Task<IEnumerable<Book>> GetAll();

    Task<Book> GetById(int id);

    Task<Book> Create(Book book);

    Task<Book> Update(Book book);

    Task<Book> Patch(Book book);

    Task<bool> Delete(Book book);
}