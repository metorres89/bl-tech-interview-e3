using Microsoft.AspNetCore.Mvc;
using BlTechInterviewE3.Business.Domain;
using BlTechInterviewE3.Business.Service.Contract;

namespace BlTechInterviewE3.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private IBookService _bookService;
    private readonly ILogger<BookController> _logger;

    public BookController(
        ILogger<BookController> logger,
        IBookService bookService
    )
    {
        _logger = logger;
        _bookService = bookService;
    }

    [HttpGet(Name = "GetBook")]
    public async Task<IEnumerable<Book>> Get()
    {
        IEnumerable<Book> books = await _bookService.GetAll();
        return books;
    }
}
