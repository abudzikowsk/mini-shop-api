using System.ComponentModel.DataAnnotations;

namespace MiniShopApi.ViewModels;

public class UpdateProductViewModel
{
        [MaxLength(30)]
        public string Name { get; set; }
        
        [Range(0.01, 999999.99)]
        public decimal? Price { get; set; }		
}