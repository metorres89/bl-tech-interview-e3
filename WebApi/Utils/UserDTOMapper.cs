using BlTechInterviewE3.Business.Domain;
using BlTechInterviewE3.WebApi.DTO.User;

namespace BlTechInterviewE3.WebApi.Utils;

public static class UserDTOMapper {
    public static UserDTO GetUserDTO(User user) {
        return new UserDTO {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Password = user.Password,
            CreateDate = user.CreateDate,
            CreateUser = user.CreateUser,
            UpdateDate = user.UpdateDate,
            UpdateUser = user.UpdateUser
        };
    }
}