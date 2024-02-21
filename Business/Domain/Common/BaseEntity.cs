namespace BlTechInterviewE3.Business.Domain.Common;

public abstract class BaseEntity {
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public string CreateUser { get; set; }
    public DateTime UpdateDate { get; set; }
    public string  UpdateUser { get; set; }

    protected BaseEntity() {
        this.Id = 0;
        this.CreateDate = DateTime.Now;
        this.CreateUser = string.Empty;
        this.UpdateDate = DateTime.Now;
        this.UpdateUser = string.Empty;
    }
}