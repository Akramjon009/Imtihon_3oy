using OrderManagementAPI.Domen.Entites.Enums;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks.Dataflow;

namespace OrderManagementAPI.Domen.Entites.DTOs
{
    public class UserDTO
    {
        public string? FullName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string Login { get; set; }

        [MinLength(8)]
        public string Password { get; set; }
        public Role Role { get; set; }
        public long Many {  get; set; }
    }
}
