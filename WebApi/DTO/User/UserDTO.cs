using BlTechInterviewE3.WebApi.DTO.Common;

namespace BlTechInterviewE3.WebApi.DTO.User;

public class UserDTO : BaseEntityDTO {
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public UserDTO() : base() {
        this.FirstName = string.Empty;
        this.LastName = string.Empty;
        this.Email = string.Empty;
        this.Password = string.Empty;
    }
}