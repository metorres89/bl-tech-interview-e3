namespace BlTechInterviewE3.WebApi.DTO.Book;

public class UpsertBookDTO {
    public string Title { get; set; }
    public string ISBN { get; set; }
    public string Author { get; set; }

    public UpsertBookDTO() {
        this.Title = string.Empty;
        this.ISBN = string.Empty;
        this.Author = string.Empty;
    }
}