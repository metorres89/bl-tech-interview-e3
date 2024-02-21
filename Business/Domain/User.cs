using BlTechInterviewE3.Business.Domain.Common;

namespace BlTechInterviewE3.Business.Domain;

public class User : BaseEntity {
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public User() : base() {
        this.FirstName = string.Empty;
        this.LastName = string.Empty;
        this.Email = string.Empty;
        this.Password = string.Empty;
    }
}
