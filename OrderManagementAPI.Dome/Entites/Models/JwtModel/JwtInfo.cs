namespace OrderManagementAPI.Domen.Entites.Models.JwtModel
{
    public class JwtInfo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
