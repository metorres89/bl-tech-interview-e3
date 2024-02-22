using BlTechInterviewE3.WebApi.DTO.Common;

namespace BlTechInterviewE3.WebApi.DTO.Book;

public class BookDTO : BaseEntityDTO {
    public string Title { get; set; }
    public string ISBN { get; set; }
    public string Author { get; set; }

    public BookDTO() : base() {
        this.Title = string.Empty;
        this.ISBN = string.Empty;
        this.Author = string.Empty;
    }
}