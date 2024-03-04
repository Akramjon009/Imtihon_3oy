namespace OrderManagementAPI.Domen.Entites.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public long SallerId { get; set; }
        public string SallerName { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public long Caunt { get; set; }
        public long price { get; set; }
    }
}
