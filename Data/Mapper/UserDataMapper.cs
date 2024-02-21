using BlTechInterviewE3.Business.Domain;
using BlTechInterviewE3.Business.Utils;
using System.Data;
using System.Data.Common;
using BlTechInterviewE3.Data.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlTechInterviewE3.Data.Mapper
{
    public class UserDataMapper : IDataMapper<User>
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        private string TableName = "user";

        public UserDataMapper(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory ?? throw new ArgumentNullException(nameof(dbConnectionFactory));
        }

        private IList<User> GetCollection(DbDataReader reader)
        {
            IList<User> users = new List<User>();
            while (reader.Read())
            {
                users.Add(
                    new User
                    {
                        Id = (int)reader["id"],
                        FirstName = (string) reader["first_name"],
                        LastName = (string) reader["last_name"],
                        Email = (string)reader["Email"],
                        Password = (string)reader["Password"],
                    }
                );
            }
            return users;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            IEnumerable<User> users;

            using (DbConnection connection = _dbConnectionFactory.GetConnection())
            {
                await connection.OpenAsync();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM {TableName}";

                    using (DbDataReader reader = await command.ExecuteReaderAsync())
                    {
                        users = GetCollection(reader);
                        reader.Close();
                    }
                }
            }

            return users;
        }

        public async Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Create(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Update(int id, User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
