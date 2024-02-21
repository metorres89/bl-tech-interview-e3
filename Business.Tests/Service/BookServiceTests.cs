using BlTechInterviewE3.Business.Service;
using BlTechInterviewE3.Business.Domain;
using BlTechInterviewE3.Business.Utils;
using Moq;

namespace Business.Tests.Service;

[TestClass]
public class BookServiceTests {

    private Mock<IDataMapper<Book>> _bookMapperMock;

    public BookServiceTests() {
        _bookMapperMock = new Mock<IDataMapper<Book>>();
    }    

    [TestMethod]
    public async Task GetAll_WhenThereAreBooks_ShouldReturnABookCollection() {
        
        //arrange
        List<Book> mockedBooks = new List<Book>() {
            new Book { Id = 1 },
            new Book { Id = 2 }
        };

        _bookMapperMock.Setup(x => x.GetAll()).ReturnsAsync(mockedBooks);

        BookService service = new BookService(_bookMapperMock.Object);

        //act
        IEnumerable<Book> collection = await service.GetAll();
        
        //assert
        Assert.IsNotNull(collection, "the collection should not be null");
        Assert.IsTrue(collection.Any(), "the collection has elements");
    }

    [TestMethod]
    public async Task GetById_WhenThereAreBooks_ShouldReturnASingleBook() {
        
        //arrange
        Book mockedBook = new Book { Id = 1 };
        _bookMapperMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(mockedBook);

        BookService service = new BookService(_bookMapperMock.Object);

        //act
        Book entity = await service.GetById(1);
        
        //assert
        Assert.IsNotNull(entity, "the entity should not be null");
    }

    [TestMethod]
    public async Task Create_WhenThereAreNoExceptions_ShouldReturnCreatedBook() {
        
        //arrange
        Book mockedBook = new Book { Id = 1 };
        _bookMapperMock.Setup(x => x.Create(It.IsAny<Book>())).ReturnsAsync(mockedBook);

        BookService service = new BookService(_bookMapperMock.Object);

        //act
        Book entity = await service.Create(new Book());
        
        //assert
        Assert.IsNotNull(entity, "the entity should not be null");
    }

    [TestMethod]
    public async Task Update_WhenThereAreNoExceptions_ShouldReturnUpdatedBook() {
        
        //arrange
        Book mockedBook = new Book { Id = 1 };
        _bookMapperMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<Book>())).ReturnsAsync(mockedBook);

        BookService service = new BookService(_bookMapperMock.Object);

        //act
        Book entity = await service.Update(new Book { Id = 1 });
        
        //assert
        Assert.IsNotNull(entity, "the entity should not be null");
    }

    [TestMethod]
    public async Task Patch_WhenThereAreNoExceptions_ShouldReturnPatchedBook() {
        
        //arrange
        Book mockedBook = new Book { Id = 1 };
        
        _bookMapperMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(mockedBook);
        _bookMapperMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<Book>())).ReturnsAsync(mockedBook);

        BookService service = new BookService(_bookMapperMock.Object);

        //act
        Book entity = await service.Patch(new Book { Id = 1 });
        
        //assert
        Assert.IsNotNull(entity, "the entity should not be null");
    }

    [TestMethod]
    public async Task Delete_WhenThereAreNoExceptions_ShouldReturnDeleteStatus() {
        
        //arrange
        _bookMapperMock.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(true);

        BookService service = new BookService(_bookMapperMock.Object);

        //act
        bool deleteStatus = await service.Delete(new Book { Id = 1 });
        
        //assert
        Assert.IsTrue(deleteStatus, "Delete should return the status of the operation");
    }
}