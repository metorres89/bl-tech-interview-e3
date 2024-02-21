using BlTechInterviewE3.Business.Service;
using BlTechInterviewE3.Business.Domain;
using BlTechInterviewE3.Business.Utils;
using Moq;

namespace Business.Tests.Service;

[TestClass]
public class AuthorServiceTests {

    private Mock<IDataMapper<Author>> _authorMapperMock; 

    public AuthorServiceTests() {
        this._authorMapperMock = new Mock<IDataMapper<Author>>();
    }

    [TestMethod]
    public async Task GetAll_WhenThereAreAuthors_ShouldReturnAnAuthorCollection() {
        
        //arrange

        List<Author> mockedAuthors = new List<Author>() {
            new Author { Id = 1 },
            new Author { Id = 2 }
        };
        this._authorMapperMock.Setup(x => x.GetAll()).ReturnsAsync(mockedAuthors);

        AuthorService service = new AuthorService(this._authorMapperMock.Object);

        //act
        IEnumerable<Author> collection = await service.GetAll();
        
        //assert
        Assert.IsNotNull(collection, "the collection should not be null");
        Assert.IsTrue(collection.Any(), "the collection has elements");
    }

    [TestMethod]
    public async Task GetById_WhenThereAreAuthors_ShouldReturnASingleAuthor() {
        
        //arrange
        Author mockedAuthor = new Author { Id = 1 };
        this._authorMapperMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(mockedAuthor);

        AuthorService service = new AuthorService(this._authorMapperMock.Object);

        //act
        Author entity = await service.GetById(1);
        
        //assert
        Assert.IsNotNull(entity, "the entity should not be null");
    }

    [TestMethod]
    public async Task Create_WhenThereAreNoExceptions_ShouldReturnCreatedAuthor() {
        
        //arrange
        Author mockedAuthor = new Author { Id = 1 };
        this._authorMapperMock.Setup(x => x.Create(It.IsAny<Author>())).ReturnsAsync(mockedAuthor);

        AuthorService service = new AuthorService(this._authorMapperMock.Object);

        //act
        Author entity = await service.Create(new Author());
        
        //assert
        Assert.IsNotNull(entity, "the entity should not be null");
    }

    [TestMethod]
    public async Task Update_WhenThereAreNoExceptions_ShouldReturnUpdatedAuthor() {
        
        //arrange
        Author mockedAuthor = new Author { Id = 1 };
        this._authorMapperMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<Author>())).ReturnsAsync(mockedAuthor);

        AuthorService service = new AuthorService(this._authorMapperMock.Object);

        //act
        Author entity = await service.Update(new Author { Id = 1 });
        
        //assert
        Assert.IsNotNull(entity, "the entity should not be null");
    }

    [TestMethod]
    public async Task Patch_WhenThereAreNoExceptions_ShouldReturnPatchedAuthor() {
        
        //arrange
        Author mockedAuthor = new Author { Id = 1 };
        this._authorMapperMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<Author>())).ReturnsAsync(mockedAuthor);

        AuthorService service = new AuthorService(this._authorMapperMock.Object);

        //act
        Author entity = await service.Patch(new Author { Id = 1 });
        
        //assert
        Assert.IsNotNull(entity, "the entity should not be null");
    }

    [TestMethod]
    public async Task Delete_WhenThereAreNoExceptions_ShouldReturnDeleteStatus() {
        
        //arrange
        this._authorMapperMock.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(true);

        AuthorService service = new AuthorService(this._authorMapperMock.Object);

        //act
        bool deleteStatus = await service.Delete(new Author { Id = 1 });
        
        //assert
        Assert.IsTrue(deleteStatus, "Delete should return the status of the operation");
    }
}