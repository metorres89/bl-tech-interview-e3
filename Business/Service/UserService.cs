using BlTechInterviewE3.Business.Domain;
using BlTechInterviewE3.Business.Service.Contract;
using BlTechInterviewE3.Business.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlTechInterviewE3.Business.Service
{
    public class UserService : IUserService
    {
        private readonly IUserDataMapper _userDataMapper;

        public UserService(IUserDataMapper userDataMapper)
        {
            _userDataMapper = userDataMapper ?? throw new ArgumentNullException("User data mapper is null");
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            IEnumerable<User> users = await _userDataMapper.GetAll();
            return users;
        }

        public async Task<User> GetById(int id)
        {
            User user = await _userDataMapper.GetById(id);
            return user;
        }

        public async Task<User> GetByCredentials(string email, string password) {
            User user = await _userDataMapper.GetByCredentials(new User {
                Email = email,
                Password = password
            });
            return user;
        }

        public async Task<User> Create(User user)
        {
            user = await _userDataMapper.Create(user);
            return user;
        }

        public async Task<User> Update(User user)
        {
            if (user.Id == 0)
                throw new ArgumentException("User has an invalid ID");

            user = await _userDataMapper.Update(user.Id, user);

            return user;
        }

        public async Task<User> Patch(User user)
        {
            if (user.Id == 0)
                throw new ArgumentException("User has an invalid ID");

            User userToPatch = await _userDataMapper.GetById(user.Id);

            if (userToPatch == null)
                throw new InvalidOperationException($"There is no user with ID: {user.Id}. Patch operation can't be completed.");

            if (user.Email != null && user.Email != userToPatch.Email) userToPatch.Email = user.Email;
            if (user.FirstName != null && user.FirstName != userToPatch.FirstName) userToPatch.FirstName = user.FirstName;
            if (user.LastName != null && user.LastName != userToPatch.LastName) userToPatch.LastName = user.LastName;

            user = await _userDataMapper.Update(userToPatch.Id, userToPatch);

            return user;
        }

        public async Task<bool> Delete(User user)
        {
            if (user.Id == 0)
                throw new ArgumentException("User has an invalid ID");

            bool deleteStatus = await _userDataMapper.Delete(user.Id);
            return deleteStatus;
        }
    }
}
