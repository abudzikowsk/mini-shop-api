using System;
using System.ComponentModel.DataAnnotations;

namespace MiniShopApi.ViewModels
{
	public class CreateProductViewModel
	{
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 999999.99)]
        public decimal Price { get; set; }
    }
}

