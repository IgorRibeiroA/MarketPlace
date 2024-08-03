namespace MarketPlace.Domain.Entities
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string CNPJ { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Product> Products { get; set; }


    }

}

