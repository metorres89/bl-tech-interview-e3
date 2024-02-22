namespace BlTechInterviewE3.WebApi.DTO.Common;

public abstract class BaseEntityDTO {
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public string CreateUser { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string?  UpdateUser { get; set; }

    protected BaseEntityDTO() {
        this.Id = 0;
        this.CreateDate = DateTime.Now;
        this.CreateUser = string.Empty;
        this.UpdateDate = null;
        this.UpdateUser = null;
    }
}