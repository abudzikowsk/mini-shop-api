using System;
using System.ComponentModel.DataAnnotations;

namespace MiniShopApi.ViewModels
{
	public class CreateUserViewModel
	{
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string Surname { get; set; }
    }
}

