namespace WebClient.Models
{
    public class MenuItemsSelection
    {
        public long Id { get; set; }
        public Menu Menu { get; set; }
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}