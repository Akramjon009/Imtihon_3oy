using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.Application.Abstractions.IService;
using OrderManagementAPI.Attrebutes;
using OrderManagementAPI.Domen.Entites.DTOs;
using OrderManagementAPI.Domen.Entites.Enums;
using OrderManagementAPI.Domen.Entites.Models;
using OrderManagementAPI.Domen.Entites.ViewModel;
using OrderManagementAPI.ExternalServices;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserControllers : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public UserControllers(IUserService userService, IWebHostEnvironment webHostEnvironment)
        {
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        [IdentityFilter(Permission.CreateUser)]
        public async Task<ActionResult<UserModel>> CreateUser([FromForm] UserDTO userDTO,IFormFile path)
        {
            PictureExternalService service = new PictureExternalService(_webHostEnvironment);
            string picturePath =await service.AddPictureAndGetPath(path);
            var result = await _userService.CreateUser(userDTO,picturePath);

            return Ok(result);
        }
        [HttpGet]
        [IdentityFilter(Permission.GetAllUser)]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllUser()
        {
            var result = await _userService.GetAllUser();
            return Ok(result);
        }
        [HttpGet]
        [IdentityFilter(Permission.GetUserById)]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUserById(long id)
        {
            var result = await _userService.GetUserById(id);
            return Ok(result);
        }
        [HttpGet]
        [IdentityFilter(Permission.GetUserByLogin)]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUserByLogin(string login)
        {
            var result = await _userService.GetUserByLogin(login);
            return Ok(result);
        }
        [HttpPut]
        [IdentityFilter(Permission.UpdateUser)]
        public async Task<ActionResult<UserModel>> UpdateUser(long id, UserDTO userDTO)
        {
            var result = await _userService.UpdateUser(id, userDTO);
            return Ok(result);
        }
        [HttpPatch]
        [IdentityFilter(Permission.UpdateUserName)]
        public async Task<ActionResult<UserModel>> UpdateUserName(long id, string name)
        {
            var result = await _userService.UpdateUserName(id, name);
            return Ok(result);
        }
        [HttpPatch]
        [IdentityFilter(Permission.UpdateUserEmail)]
        public async Task<ActionResult<UserModel>> UpdateUserEmail(long id, string email)
        {
            var result = await _userService.UpdateUserEmail(id, email);
            return Ok(result);
        }
        [HttpPatch]
        [IdentityFilter(Permission.UpdateUserLogin)]
        public async Task<ActionResult<UserModel>> UpdateUserLogin(long id, string Login)
        {
            var result = await _userService.UpdateUserLogin(id, Login);
            return Ok(result);
        }
        [HttpPatch]
        [IdentityFilter(Permission.UpdateUserPassword)]
        public async Task<ActionResult<UserModel>> UpdateUserPassword(long id, string password)
        {
            var result = await _userService.UpdateUserPassword(id, password);
            return Ok(result);
        }
        [HttpPatch]
        [IdentityFilter(Permission.UpdateUserOrder)]
        public async Task<ActionResult<UserModel>> BuyProduct(string login, string ProductName, string descripting)
        {
            var result = await _userService.UpdateUserOrder(login, ProductName, descripting);
            return Ok(result);
        }
        [HttpPatch]
        [IdentityFilter(Permission.GetPdfPath)]
        public async Task<string> GetUserInfo() 
        {
            return await _userService.GetPdfPath();
        }
        [HttpPatch]
        [IdentityFilter(Permission.UpdatePohot)]
        public async Task<bool> UpdatePhoto(long id, IFormFile path) 
        {
            PictureExternalService service = new PictureExternalService(_webHostEnvironment);
            string picturePath = await service.AddPictureAndGetPath(path);
            return await _userService.UpdatePhoto(id, picturePath);

        }


    }
}
