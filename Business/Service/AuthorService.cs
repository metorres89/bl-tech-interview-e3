using BlTechInterviewE3.Business.Domain;
using BlTechInterviewE3.Business.Utils;
using BlTechInterviewE3.Business.Service.Contract;

namespace BlTechInterviewE3.Business.Service;

public class AuthorService : IAuthorService {

    private IDataMapper<Author> _authorDataMapper;

    public AuthorService(IDataMapper<Author> authorDataMapper) {
        this._authorDataMapper = authorDataMapper ?? throw new ArgumentNullException("Author data mapper is null");
    }

    public async Task<IEnumerable<Author>> GetAll() {
        IEnumerable<Author> authors = await this._authorDataMapper.GetAll();
        return authors;
    }

    public async Task<Author> GetById(int id) {
        throw new NotImplementedException("Method not implemented!");
    }

    public async Task<Author> Create(Author author) {
        throw new NotImplementedException("Method not implemented!");
    }

    public async Task<Author> Update(Author author) {
        throw new NotImplementedException("Method not implemented!");
    }

    public async Task<Author> Patch(Author author) {
        throw new NotImplementedException("Method not implemented!");
    }

    public async Task<bool> Delete(Author author) {
        throw new NotImplementedException("Method not implemented!");
    }
}