using FeedBridge_00.Models.Status;

namespace FeedBridge_00.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public TypeStatus Category { get; set; } // eat or juice
        public int Quantity { get; set; }
        public ProductStatus Status { get; set; } // Exist or not
        public DateTime Expiration { get; set; } // تاريخ البدأ وتاريخ الانتهاء 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int Admin_id {  get; set; }
        public Admin Admin {  get; set; }

        public int InventoryEmployee_id { get; set; }
        public InventoryEmployee InventoryEmployee { get; set; }

        public List<Cart> Carts { get; set; } = new();
    }
}
