using BlTechInterviewE3.Business.Domain.Common;

namespace BlTechInterviewE3.Business.Domain;

public class BookCopy : BaseEntity {
    public Book Book { get; set; }

    public User BorrowingUser { get; set; }

    public DateTime ReturnDate { get; set; }

    public BookCopy() : base() {
        this.Book = new Book();
        this.BorrowingUser = new User();
        this.ReturnDate = DateTime.Now;
    }
}
