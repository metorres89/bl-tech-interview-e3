using Microsoft.AspNetCore.Mvc;
using BlTechInterviewE3.Business.Domain;
using Microsoft.AspNetCore.Components.Web;

namespace BlTechInterviewE3.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly ILogger<BookController> _logger;

    public BookController(ILogger<BookController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetBook")]
    public IEnumerable<Book> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Book
        {
            Title = "Your fav book",
            ISBN = "978-3-16-148410-0"
        })
        .ToArray();
    }
}
