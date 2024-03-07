using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.Application.Abstractions.IService;
using OrderManagementAPI.Attrebutes;
using OrderManagementAPI.Domen.Entites.DTOs;
using OrderManagementAPI.Domen.Entites.Enums;
using OrderManagementAPI.Domen.Entites.Models;
using OrderManagementAPI.Domen.Entites.ViewModel;
using OrderManagementAPI.ExternalServices;
using System.Runtime.CompilerServices;

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
        [IdentityFilter(Permission.GetMany)]
        public async Task<string> GetMany(long id, string password) 
        {
            var result = await _userService.GetMany(id, password);
            return result;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUserById(long id)
        {
            var result = await _userService.GetUserById(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUserByLogin(string login)
        {
            var result = await _userService.GetUserByLogin(login);
            return Ok(result);
        }
        [HttpPut]
        [IdentityFilter(Permission.UpdateUser)]
        public async Task<ActionResult<UserModel>> UpdateUser(long id,string password, UserDTO userDTO)
        {
            var result = await _userService.UpdateUser(id,password, userDTO);
            return Ok(result);
        }
        [HttpPatch]
        [IdentityFilter(Permission.UpdateUserName)]
        public async Task<ActionResult<UserModel>> UpdateUserName(long id, string password, string name)
        {
            var result = await _userService.UpdateUserName(id, password, name);
            return Ok(result);
        }
        [HttpPatch]
        [IdentityFilter(Permission.UpdateUserEmail)]
        public async Task<ActionResult<UserModel>> UpdateUserEmail(long id, string password, string email)
        {
            var result = await _userService.UpdateUserEmail(id, password, email);
            return Ok(result);
        }
        [HttpPatch]
        [IdentityFilter(Permission.UpdateUserLogin)]
        public async Task<ActionResult<UserModel>> UpdateUserLogin(long id, string password, string Login)
        {
            var result = await _userService.UpdateUserLogin(id, password, Login);
            return Ok(result);
        }
        [HttpPatch]
        [IdentityFilter(Permission.UpdateUserPassword)]
        public async Task<ActionResult<UserModel>> UpdateUserPassword(long id, string OldPassword, string NewPassword)
        {
            var result = await _userService.UpdateUserPassword(id, OldPassword,NewPassword);
            return Ok(result);
        }
        [HttpPatch]
        [IdentityFilter(Permission.UpdateUserOrder)]
        public async Task<ActionResult<UserModel>> BuyProduct(string login,string password, string ProductName, string descripting)
        {
            var result = await _userService.UpdateUserOrder(login,password, ProductName, descripting);
            return Ok(result);
        }
        [HttpPatch]
        [IdentityFilter(Permission.GetPdfPath)]
        public async Task<string> GetUserInfo() 
        {
            return await _userService.GetPdfPath();
        }
        [HttpPatch]
        [IdentityFilter(Permission.UpdatePhoto)]
        public async Task<bool> UpdatePhoto(long id, IFormFile path) 
        {
            PictureExternalService service = new PictureExternalService(_webHostEnvironment);
            string picturePath = await service.AddPictureAndGetPath(path);
            return await _userService.UpdatePhoto(id, picturePath);


        }
        [HttpDelete]
        [IdentityFilter(Permission.DeleteUser)]
        public async Task<bool> DeleteUser(long id, string password) 
        {
            return await _userService.DeleteUser(id,password);
        }
        [HttpGet]
        [IdentityFilter(Permission.GetPicture)]
        public async Task<IActionResult> GetPicture(string login)
        {
            var path = await _userService.GetPicture(login);
            if (path != null) 
            {
                var fileBytes = System.IO.File.ReadAllBytes(path);
                return File(fileBytes, "image/jpeg");
            }
            return Ok("User dosn't have photo");
        }
    }
}
