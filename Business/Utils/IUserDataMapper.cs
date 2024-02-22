using BlTechInterviewE3.Business.Domain;

namespace BlTechInterviewE3.Business.Utils;

public interface IUserDataMapper : IDataMapper<User> {
    Task<User> GetByCredentials(User user);
}