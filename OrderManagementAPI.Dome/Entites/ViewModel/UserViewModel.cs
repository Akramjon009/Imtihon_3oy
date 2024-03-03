namespace OrderManagementAPI.Domen.Entites.ViewModel
{
    public class UserViewModel
    {
        public string Login;

        public string? Name { get; set; }
        public string? Email { get; set; }
        public Role Role { get; set; }
    }
}
