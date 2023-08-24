using System;
using System.ComponentModel.DataAnnotations;
using MiniShopApi.Database.Entitites;

namespace MiniShopApi.ViewModels
{
	public class CreateOrderViewModel
	{
        [Required]
        public string UserId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Quantity { get; set; }
    }
}

