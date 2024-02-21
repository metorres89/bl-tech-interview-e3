using BlTechInterviewE3.Business.Service;
using BlTechInterviewE3.Business.Domain;

namespace Business.Tests.Service;

[TestClass]
public class BookServiceTests {

    [TestMethod]
    public async Task GetAll_When_ShouldReturnABookCollection() {
        
        //arrange
        BookService service = new BookService();

        //act
        IEnumerable<Book> collection = await service.GetAll();
        
        //assert
        Assert.IsNotNull(collection, "the collection should not be null");
    }
}