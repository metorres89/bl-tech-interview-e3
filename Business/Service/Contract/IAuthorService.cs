using BlTechInterviewE3.Business.Domain;

namespace BlTechInterviewE3.Business.Service.Contract;

public interface IAuthorService {
    Task<IEnumerable<Author>> GetAll();

    Task<Author> GetById(int id);

    Task<Author> Create(Author author);

    Task<Author> Update(Author author);

    Task<Author> Patch(Author author);

    Task<bool> Delete(Author author);
}