namespace BlTechInterviewE3.Data.Mapper;

public interface IDataMapper<T> {

    Task<IEnumerable<T>> GetAll();

    Task<T> GetById(int id);

    Task<T> Create(T entity);

    Task<T> Update(int id, T entity);

    Task<bool> Delete(int id);
}