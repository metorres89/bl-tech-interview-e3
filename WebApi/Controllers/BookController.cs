using Microsoft.AspNetCore.Mvc;
using BlTechInterviewE3.Business.Domain;
using BlTechInterviewE3.Business.Service.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace BlTechInterviewE3.WebApi.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("api/books")]
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        var books = await _bookService.GetAll();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBookById(int id)
    {
        var book = await _bookService.GetById(id);
        
        if (book == null)
            return NotFound();

        return Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult<Book>> CreateBook([FromBody] Book book)
    {
        var createdBook = await _bookService.Create(book);
        return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBook);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Book>> UpdateBook(int id, [FromBody] Book book)
    {
        if (id != book.Id)
            return BadRequest();

        try
        {
            var updatedBook = await _bookService.Update(book);
            return Ok(updatedBook);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<Book>> PatchBook(int id, [FromBody] Book book)
    {
        if (id != book.Id)
            return BadRequest();

        try
        {
            var patchedBook = await _bookService.Patch(book);
            return Ok(patchedBook);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteBook(int id)
    {
        var bookToDelete = await _bookService.GetById(id);

        if (bookToDelete == null)
            return NotFound();

        var deleteStatus = await _bookService.Delete(bookToDelete);
        return Ok(deleteStatus);
    }
}
