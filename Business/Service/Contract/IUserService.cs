using BlTechInterviewE3.Business.Domain;

namespace BlTechInterviewE3.Business.Service.Contract
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();

        Task<User> GetById(int id);

        Task<User> GetByCredentials(string email, string password);

        Task<User> Create(User user);

        Task<User> Update(User user);

        Task<User> Patch(User user);

        Task<bool> Delete(User user);
    }
}
