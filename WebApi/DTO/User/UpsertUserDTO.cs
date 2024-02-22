namespace BlTechInterviewE3.WebApi.DTO.User;

public class UpsertUserDTO {
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public UpsertUserDTO() {
        this.FirstName = string.Empty;
        this.LastName = string.Empty;
        this.Email = string.Empty;
        this.Password = string.Empty;
    }
}