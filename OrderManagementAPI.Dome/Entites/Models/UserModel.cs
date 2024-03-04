using OrderManagementAPI.Domen.Entites.Enums;

namespace OrderManagementAPI.Domen.Entites.Models
{
    public class UserModel
    {
        public long? Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string? path { get; set; }
        public string? Orders { get; set; }
        public long? Many { get; set; }
    }
}
