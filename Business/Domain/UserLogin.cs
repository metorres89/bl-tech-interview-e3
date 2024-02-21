using BlTechInterviewE3.Business.Domain.Common;

namespace BlTechInterviewE3.Business.Domain;

public class UserLogin {
    public string Email { get; set; }

    public string Password { get; set; }

    public UserLogin() {
        this.Email = string.Empty;
        this.Password = string.Empty;
    }
}
