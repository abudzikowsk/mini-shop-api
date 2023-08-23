namespace MiniShopApi.ViewModels
{
	public class OrderViewModel
	{
        public int Id { get; set; }
        public string UserFirstname { get; set; }
        public string UserSurname { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}

