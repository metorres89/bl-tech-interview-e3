namespace BlTechInterviewE3.WebApi.DTO.User;

public class UserLoginDTO {
    public string Email { get; set; }
    public string Password { get; set; }

    public UserLoginDTO() {
        this.Email = string.Empty;
        this.Password = string.Empty;
    }
}
