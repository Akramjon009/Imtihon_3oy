using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.Application.Abstractions.IService;
using OrderManagementAPI.Domen.Entites.DTOs;
using OrderManagementAPI.Domen.Entites.Models;
using OrderManagementAPI.Domen.Entites.ViewModel;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        private readonly IUserService _userService;

        public UserControllers(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> CreateUser(UserDTO userDTO)
        {
            var result = await _userService.Create(userDTO);

            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllUser()
        {
            var result = await _userService.GetAll();
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUserById(long id)
        {
            var result = await _userService.GetById(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUserByLogin(string login)
        {
            var result = await _userService.GetByLogin(login);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<UserModel>> UpdateUser(long id, UserDTO userDTO)
        {
            var result = await _userService.Update(id, userDTO);
            return Ok(result);
        }
        [HttpPatch]
        public async Task<ActionResult<UserModel>> UpdateUserName(long id, string name)
        {
            var result = await _userService.UpdateName(id, name);
            return Ok(result);
        }
        [HttpPatch]
        public async Task<ActionResult<UserModel>> UpdateUserEmail(long id, string email)
        {
            var result = await _userService.UpdateEmail(id, email);
            return Ok(result);
        }
        [HttpPatch]
        public async Task<ActionResult<UserModel>> UpdateUserLogin(long id, string Login)
        {
            var result = await _userService.UpdateLogin(id, Login);
            return Ok(result);
        }
        [HttpPatch]
        public async Task<ActionResult<UserModel>> UpdateUserPassword(long id, string password)
        {
            var result = await _userService.UpdatePassword(id, password);
            return Ok(result);
        }
        [HttpPatch]
        public async Task<ActionResult<UserModel>> BuyProduct(string login, string ProductName, string descripting)
        {
            var result = await _userService.UpdateOrder(login,ProductName,descripting);
            return Ok(result);
        
        
        
        
        
        
        
        }






    }
}
