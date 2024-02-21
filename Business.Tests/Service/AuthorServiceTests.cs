using BlTechInterviewE3.Business.Service;
using BlTechInterviewE3.Business.Domain;

namespace Business.Tests.Service;

[TestClass]
public class AuthorServiceTests {

    [TestMethod]
    public async Task GetAll_When_ShouldReturnAnAuthorCollection() {
        
        //arrange
        AuthorService service = new AuthorService();

        //act
        IEnumerable<Author> collection = await service.GetAll();
        
        //assert
        Assert.IsNotNull(collection, "the collection should not be null");
    }
}