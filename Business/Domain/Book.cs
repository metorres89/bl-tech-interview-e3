using BlTechInterviewE3.Business.Domain.Common;

namespace BlTechInterviewE3.Business.Domain;

public class Book : BaseEntity {
    public string Title { get; set; }
    public string ISBN { get; set; }
    public Author Author { get; set; }

    public Book() : base() {
        this.Title = string.Empty;
        this.ISBN = string.Empty;
        this.Author = new Author();
    }
}
