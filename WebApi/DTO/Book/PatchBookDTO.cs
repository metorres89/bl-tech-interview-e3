namespace BlTechInterviewE3.WebApi.DTO.Book;

public class PatchBookDTO {
    public string? Title { get; set; }
    public string? ISBN { get; set; }
    public string? Author { get; set; }

    public PatchBookDTO() {
        this.Title = null;
        this.ISBN = null;
        this.Author = null;
    }
}