namespace BlTechInterviewE3.Business.Domain;

public class Book {
    public int Id { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }

    public Book() {
        this.Id = 0;
        this.Title = string.Empty;
        this.ISBN = string.Empty;
    }
}
