using BlTechInterviewE3.Business.Domain;
using BlTechInterviewE3.Business.Utils;
using BlTechInterviewE3.Business.Service.Contract;

namespace BlTechInterviewE3.Business.Service;

public class AuthorService : IAuthorService {

    private IDataMapper<Author> _authorDataMapper;

    public AuthorService(IDataMapper<Author> authorDataMapper) {
        _authorDataMapper = authorDataMapper ?? throw new ArgumentNullException("Author data mapper is null");
    }

    public async Task<IEnumerable<Author>> GetAll() {
        IEnumerable<Author> authors = await _authorDataMapper.GetAll();
        return authors;
    }

    public async Task<Author> GetById(int id) {
        Author author = await _authorDataMapper.GetById(id);
        return author;
    }

    public async Task<Author> Create(Author author) {
        author = await _authorDataMapper.Create(author);
        return author;
    }

    public async Task<Author> Update(Author author) {
        if (author.Id == 0)
            throw new ArgumentException("Author has an invalid ID");

        author = await _authorDataMapper.Update(author.Id, author);

        return author;
    }

    public async Task<Author> Patch(Author author) {
        if (author.Id == 0)
            throw new ArgumentException("Author has an invalid ID");

        Author authorToPatch = await _authorDataMapper.GetById(author.Id);

        if (authorToPatch == null)
            throw new InvalidOperationException($"There is no author with id: {author.Id}. Patch operation can't be completed.");

        if (author.FirstName != null && author.FirstName != authorToPatch.FirstName) authorToPatch.FirstName = author.FirstName;
        if (author.LastName != null && author.LastName != authorToPatch.LastName) authorToPatch.LastName = author.LastName;

        author = await _authorDataMapper.Update(authorToPatch.Id, authorToPatch);

        return author;
    }

    public async Task<bool> Delete(Author author) {
        if (author.Id == 0)
            throw new ArgumentException("Author has an invalid ID");

        bool deleteStatus = await _authorDataMapper.Delete(author.Id);
        return deleteStatus;
    }
}