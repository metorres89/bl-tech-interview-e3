namespace BlTechInterviewE3.WebApi.DTO.User;

public class PatchUserDTO {
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public PatchUserDTO() {
        this.FirstName = null;
        this.LastName = null;
        this.Email = null;
        this.Password = null;
    }
}