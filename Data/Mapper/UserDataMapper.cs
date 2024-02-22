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
    public class UserDataMapper : IUserDataMapper
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        private string TableName = "public.user";

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
                        Id = reader.IsDBNull(reader.GetOrdinal("id")) ? 0 : (int)reader["id"],
                        FirstName = reader.IsDBNull(reader.GetOrdinal("first_name")) ? null : (string)reader["first_name"],
                        LastName = reader.IsDBNull(reader.GetOrdinal("last_name")) ? null : (string)reader["last_name"],
                        Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : (string)reader["email"],
                        Password = reader.IsDBNull(reader.GetOrdinal("password")) ? null : (string)reader["password"],
                        CreateDate = reader.IsDBNull(reader.GetOrdinal("create_date")) ? DateTime.MinValue : (DateTime)reader["create_date"],
                        CreateUser = reader.IsDBNull(reader.GetOrdinal("create_user")) ? null : (string)reader["create_user"],
                        UpdateDate = reader.IsDBNull(reader.GetOrdinal("update_date")) ? (DateTime?)null : (DateTime?)reader["update_date"],
                        UpdateUser = reader.IsDBNull(reader.GetOrdinal("update_user")) ? null : (string)reader["update_user"]
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
            using (DbConnection connection = _dbConnectionFactory.GetConnection())
            {
                await connection.OpenAsync();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM {TableName} WHERE id = @id";
                    command.AddParameterWithValue("id", id);

                    using (DbDataReader reader = await command.ExecuteReaderAsync())
                    {
                        return GetCollection(reader).FirstOrDefault();
                    }
                }
            }
        }

        public async Task<User> GetByCredentials(User user)
        {
            using (DbConnection connection = _dbConnectionFactory.GetConnection())
            {
                await connection.OpenAsync();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM {TableName} WHERE email = @email AND password = @password";
                    
                    command.AddParameterWithValue("email", user.Email);

                    command.AddParameterWithValue("password", user.Password);

                    using (DbDataReader reader = await command.ExecuteReaderAsync())
                    {
                        return GetCollection(reader).FirstOrDefault();
                    }
                }
            }
        }

        public async Task<User> Create(User entity)
        {
            using (DbConnection connection = _dbConnectionFactory.GetConnection())
            {
                await connection.OpenAsync();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = $@"
                        INSERT INTO {TableName} (first_name, last_name, email, password, create_date, create_user)
                        VALUES (@first_name, @last_name, @email, @password, @create_date, @create_user)
                        RETURNING *";

                    command.AddParameterWithValue("first_name", entity.FirstName);
                    command.AddParameterWithValue("last_name", entity.LastName);
                    command.AddParameterWithValue("email", entity.Email);
                    command.AddParameterWithValue("password", entity.Password);
                    command.AddParameterWithValue("create_date", entity.CreateDate);
                    command.AddParameterWithValue("create_user", entity.CreateUser);

                    using (DbDataReader reader = await command.ExecuteReaderAsync())
                    {
                        return GetCollection(reader).FirstOrDefault();
                    }
                }
            }
        }

        public async Task<User> Update(int id, User entity)
        {
            using (DbConnection connection = _dbConnectionFactory.GetConnection())
            {
                await connection.OpenAsync();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = $@"
                        UPDATE {TableName}
                        SET 
                            first_name = @first_name, 
                            last_name = @last_name, 
                            email = @email, 
                            password = @password, 
                            update_date = @update_date, 
                            update_user = @update_user
                        WHERE id = @id
                        RETURNING *";

                    command.AddParameterWithValue("id", id);
                    command.AddParameterWithValue("first_name", entity.FirstName);
                    command.AddParameterWithValue("last_name", entity.LastName);
                    command.AddParameterWithValue("email", entity.Email);
                    command.AddParameterWithValue("password", entity.Password);
                    command.AddParameterWithValue("update_date", entity.UpdateDate);
                    command.AddParameterWithValue("update_user", entity.UpdateUser);

                    using (DbDataReader reader = await command.ExecuteReaderAsync())
                    {
                        return GetCollection(reader).FirstOrDefault();
                    }
                }
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (DbConnection connection = _dbConnectionFactory.GetConnection())
            {
                await connection.OpenAsync();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"DELETE FROM {TableName} WHERE id = @id";
                    command.AddParameterWithValue("id", id);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
