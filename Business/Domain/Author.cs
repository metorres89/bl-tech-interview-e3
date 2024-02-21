using BlTechInterviewE3.Business.Domain.Common;

namespace BlTechInterviewE3.Business.Domain;

public class Author : BaseEntity {
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Author() : base() {
        this.FirstName = string.Empty;
        this.LastName = string.Empty;
    }
}