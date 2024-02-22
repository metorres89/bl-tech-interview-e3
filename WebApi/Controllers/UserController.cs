using BlTechInterviewE3.Business.Domain;
using BlTechInterviewE3.Business.Service.Contract;
using BlTechInterviewE3.WebApi.DTO.User;
using BlTechInterviewE3.WebApi.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlTechInterviewE3.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(
            ILogger<UserController> logger,
            IUserService userService
        )
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userService.GetAll();
            var userDtos = users.Select(UserDTOMapper.GetUserDTO);
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var user = await _userService.GetById(id);
            
            if (user == null)
                return NotFound();

            var userDTO = UserDTOMapper.GetUserDTO(user);

            return Ok(userDTO);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UpsertUserDTO newUser)
        {
            var user = new User {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                Password = newUser.Password,
                CreateDate = DateTime.Now,
                CreateUser = User?.Identity?.Name,
                UpdateDate = null,
                UpdateUser = null
            };

            var createdUser = await _userService.Create(user);

            var createdUserDTO = UserDTOMapper.GetUserDTO(createdUser);

            return CreatedAtAction(nameof(GetUserById), new { id = createdUserDTO.Id }, createdUserDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> UpdateUser(int id, [FromBody] UpsertUserDTO userToUpdate)
        {
            if (id == 0)
                return BadRequest();

            try
            {

                var user = new User {
                    Id = id,
                    FirstName = userToUpdate.FirstName,
                    LastName = userToUpdate.LastName,
                    Email = userToUpdate.Email,
                    Password = userToUpdate.Password,
                    UpdateDate = DateTime.Now,
                    UpdateUser = User?.Identity?.Name
                };

                var updatedUser = await _userService.Update(user);
                
                var updatedUserDTO = UserDTOMapper.GetUserDTO(updatedUser);

                return Ok(updatedUserDTO);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<UserDTO>> PatchUser(int id, [FromBody] PatchUserDTO userToPatch)
        {
            if (id == 0)
                return BadRequest();

            try
            {
                var user = new User {
                    Id = id,
                    FirstName = userToPatch.FirstName,
                    LastName = userToPatch.LastName,
                    Email = userToPatch.Email,
                    Password = userToPatch.Password,
                    UpdateDate = DateTime.Now,
                    UpdateUser = User?.Identity?.Name
                };

                var patchedUser = await _userService.Patch(user);

                var userDTO = UserDTOMapper.GetUserDTO(patchedUser);

                return Ok(userDTO);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            var userToDelete = await _userService.GetById(id);

            if (userToDelete == null)
                return NotFound();

            var deleteStatus = await _userService.Delete(userToDelete);
            return Ok(deleteStatus);
        }
    }
}
