using BlTechInterviewE3.Business.Service;
using BlTechInterviewE3.Business.Domain;
using BlTechInterviewE3.Business.Utils;
using Moq;

namespace Business.Tests.Service;

[TestClass]
public class BookServiceTests {

    private Mock<IDataMapper<Book>> _bookMapperMock;

    public BookServiceTests() {
        this._bookMapperMock = new Mock<IDataMapper<Book>>();
    }    

    [TestMethod]
    public async Task GetAll_WhenThereAreBooks_ShouldReturnABookCollection() {
        
        //arrange
        List<Book> mockedBooks = new List<Book>() {
            new Book { Id = 1 },
            new Book { Id = 2 }
        };

        this._bookMapperMock.Setup(x => x.GetAll()).ReturnsAsync(mockedBooks);

        BookService service = new BookService(this._bookMapperMock.Object);

        //act
        IEnumerable<Book> collection = await service.GetAll();
        
        //assert
        Assert.IsNotNull(collection, "the collection should not be null");
    }
}