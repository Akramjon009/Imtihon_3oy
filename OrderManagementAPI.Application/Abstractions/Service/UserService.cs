﻿using OrderManagementAPI.Application.Abstractions.IRepositories;
using OrderManagementAPI.Application.Abstractions.IService;
using OrderManagementAPI.Domen.Entites.DTOs;
using OrderManagementAPI.Domen.Entites.Models;
using OrderManagementAPI.Domen.Entites.ViewModel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Linq.Expressions;


namespace OrderManagementAPI.Application.Abstractions.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductService _productService;

        public UserService(IUserRepository userRepository, IProductService productService)
        {
            _userRepository = userRepository;
            _productService = productService;
        }


        public async Task<UserModel> CreateUser(UserDTO userDTO,string path)
        {

            if (await Check(userDTO.Email, userDTO.Login))
            {
                var user = new UserModel()
                {
                    FullName = userDTO.FullName,
                    Email = userDTO.Email,
                    Login = userDTO.Login,
                    Password = userDTO.Password,
                    Role = userDTO.Role,
                    path = path
                };
                var result = await _userRepository.Create(user);

                return result;
            }
            return new UserModel();

        }


        public async Task<IEnumerable<UserViewModel>> GetAllUser()
        {
            var users = await _userRepository.GetAll();

            var result = users.Select(model => new UserViewModel
            {
                Name = model.FullName,
                Email = model.Email,
                Role = model.Role,
            });

            return result;
        }

        public async Task<UserModel> GetUserById(long Id)
        {
            var user = await _userRepository.GetByAny(x => x.Id == Id);
            if (user != null)
            {
                return user;
            }
            return null;
        }
        public async Task<UserModel> GetUserByLogin(string login)
        {
            var user = await _userRepository.GetByAny(x => x.Login == login);
            if (user != null)
            {
                return user;
            }
            return null;
        }
        public async Task<UserModel> UpdateUser(long Id, UserDTO userDTO)
        {
            if (await Check(userDTO.Email, userDTO.Login))
            {
                var old = await _userRepository.GetByAny(x => x.Id == Id);


                old.FullName = userDTO.FullName;
                old.Email = userDTO.Email;
                old.Login = userDTO.Login;
                old.Password = userDTO.Password;
                old.Role = userDTO.Role;

                var result = await _userRepository.Update(old);

                return result;
            }
            return new UserModel();

        }

        public async Task<UserModel> UpdateUserEmail(long Id, string email)
        {
            var res = await _userRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {
                if (await Check(email))
                {
                    res.Email = email;
                    var result = await _userRepository.Update(res);

                    return result;
                }
                return new UserModel();
            }
            return new UserModel();
        }

        public async Task<string> UpdateUserOrder(string login, string ProductName, string description)
        {
            if (await _productService.SelProduct(ProductName, description) != null)
            {
                var result = await _userRepository.GetByAny(x => x.Login == login);
                if (result != null)
                {
                    await _userRepository.Update(result);
                    return $"You bought {ProductName}";
                }
                return "Login is wrong";
            }
            return $"Product dosen't exist";
        }

        public async Task<UserModel> UpdateUserLogin(long Id, string login)
        {
            var res = await _userRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {
                if (await Check(null, login))
                {
                    res.Login = login;
                    var result = await _userRepository.Update(res);

                    return result;
                }
                return new UserModel();
            }
            return new UserModel();
        }

        public async Task<UserModel> UpdateUserName(long Id, string fullname)
        {
            var res = await _userRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {
                res.FullName = fullname;
                var result = await _userRepository.Update(res);

                return result;
            }
            return new UserModel();
        }

        public async Task<UserModel> UpdateUserPassword(long Id, string password)
        {
            var res = await _userRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {

                res.Password = password;
                var result = await _userRepository.Update(res);

                return result;
            }
            return new UserModel();
        }
        public async Task<bool> DeleteUser(Expression<Func<UserModel, bool>> expression)
        {
            var result = await _userRepository.Delete(expression);

            return result;
        }
        public async Task<UserModel> GetByUserEmail(string email)
        {

            var result = await _userRepository.GetByAny(x => x.Email == email);
            if (result != null)
            {
                return result;
            }
            return null;
        }
        public async Task<bool> Check(string email = null, string login = null)
        {
            var result = await _userRepository.GetByAny(x => x.Email == email || x.Login == login);
            if (result != null)
            {
                return false;
            }
            return true;

        }
        public async Task<string> GetPdfPath()
        {
            var text = "|\t\tFullName\t\t|\t\tEmail\t\t|\t\tLogin\t\t|\n";
            text += "___________________________________________________\n";

            var users = await _userRepository.GetAll();

            foreach (var user in users.Where(x => x.Role.ToString() != "Admin"))
            {
                text += $"| {user.FullName} | {user.Email} | {user.Login}|\n";
                text += "___________________________________________________\n";
            }

            DirectoryInfo projectDirectoryInfo = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent;

            var fileName = Guid.NewGuid().ToString();
            string pdfsFolder = Directory.CreateDirectory(Path.Combine(projectDirectoryInfo.FullName, "pdfs")).FullName;

            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                        .Text("Library Users")
                        .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Spacing(20);

                            x.Item().Text(text);
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                });
            })
            .GeneratePdf(Path.Combine(pdfsFolder, $"{fileName}.pdf"));

            return Path.Combine(pdfsFolder, $"{fileName}.pdf");
        }
        public async Task<bool> UpdatePhoto(long id,string path) 
        {
            var result = await _userRepository.GetByAny(x => x.Id == id);
            if (result != null)
            {
                result.path = path;
                await _userRepository.Update(result);
                return true;
            }
            return false;
        }

    }
}
