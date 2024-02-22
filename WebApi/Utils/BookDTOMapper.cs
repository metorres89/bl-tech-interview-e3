using BlTechInterviewE3.Business.Domain;
using BlTechInterviewE3.WebApi.DTO.Book;

namespace BlTechInterviewE3.WebApi.Utils;

public static class BookDTOMapper {
    public static BookDTO GetBookDTO(Book book) {
        return new BookDTO {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            ISBN = book.ISBN,
            CreateDate = book.CreateDate,
            CreateUser = book.CreateUser,
            UpdateDate = book.UpdateDate,
            UpdateUser = book.UpdateUser
        };
    }
}