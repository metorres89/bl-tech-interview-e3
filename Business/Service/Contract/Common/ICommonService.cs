namespace BlTechInterviewE3.Business.Service.Contract.Common;

public interface ICommonService<T> {
    Task<IEnumerable<T>> GetAll();

    Task<T> GetById(int id);

    Task<T> Create(T entity);

    Task<T> Update(T entity);

    Task<T> Patch(T entity);
}