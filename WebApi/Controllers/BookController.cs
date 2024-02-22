using Microsoft.AspNetCore.Mvc;
using BlTechInterviewE3.Business.Domain;
using BlTechInterviewE3.Business.Service.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BlTechInterviewE3.WebApi.DTO.Book;
using BlTechInterviewE3.WebApi.Utils;

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
    public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
    {
        var books = await _bookService.GetAll();
        var booksDtos = books.Select(BookDTOMapper.GetBookDTO);
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDTO>> GetBookById(int id)
    {
        var book = await _bookService.GetById(id);
        
        if (book == null)
            return NotFound();
        
        var bookDto = BookDTOMapper.GetBookDTO(book);
        return Ok(bookDto);
    }

    [HttpPost]
    public async Task<ActionResult<BookDTO>> CreateBook([FromBody] UpsertBookDTO newBook)
    {
        var book = new Book {
            Title = newBook.Title,
            Author = newBook.Author,
            ISBN = newBook.ISBN,
            CreateDate = DateTime.Now,
            CreateUser = User?.Identity?.Name,
            UpdateDate = null,
            UpdateUser = null
        };

        var createdBook = await _bookService.Create(book);

        var createdBookDTO = BookDTOMapper.GetBookDTO(createdBook);

        return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBookDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BookDTO>> UpdateBook(int id, [FromBody] UpsertBookDTO bookToUpdate)
    {
        if (id == 0)
            return BadRequest();

        try
        {
            var book = new Book {
                Id = id,
                Title = bookToUpdate.Title,
                Author = bookToUpdate.Author,
                ISBN = bookToUpdate.ISBN,
                UpdateDate = DateTime.Now,
                UpdateUser = User?.Identity?.Name
            };

            var updatedBook = await _bookService.Update(book);

            var bookDTO = BookDTOMapper.GetBookDTO(updatedBook);

            return Ok(bookDTO);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<BookDTO>> PatchBook(int id, [FromBody] PatchBookDTO bookToPatch)
    {
        if (id == 0)
            return BadRequest();

        try
        {

            var book = new Book {
                Id = id,
                Title = bookToPatch.Title,
                Author = bookToPatch.Author,
                ISBN = bookToPatch.ISBN,
                UpdateDate = DateTime.Now,
                UpdateUser = User?.Identity?.Name
            };

            var patchedBook = await _bookService.Patch(book);

            var bookDTO = BookDTOMapper.GetBookDTO(patchedBook);

            return Ok(bookDTO);
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
