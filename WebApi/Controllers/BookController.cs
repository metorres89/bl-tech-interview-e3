using Microsoft.AspNetCore.Mvc;
using BlTechInterviewE3.Business.Domain;
using Microsoft.AspNetCore.Components.Web;
using BlTechInterviewE3.Data.Mapper;

namespace BlTechInterviewE3.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private IDataMapper<Book> _bookDataMapper;
    private readonly ILogger<BookController> _logger;

    public BookController(
        ILogger<BookController> logger,
        IDataMapper<Book> bookDataMapper
    )
    {
        _logger = logger;
        _bookDataMapper = bookDataMapper;
    }

    [HttpGet(Name = "GetBook")]
    public async Task<IEnumerable<Book>> Get()
    {
        IEnumerable<Book> books = await _bookDataMapper.GetAll();
        return books;
    }
}
