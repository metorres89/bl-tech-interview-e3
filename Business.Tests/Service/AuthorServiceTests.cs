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
    }
}