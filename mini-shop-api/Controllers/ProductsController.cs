using System;
using Microsoft.AspNetCore.Mvc;
using MiniShopApi.Database.Repositories;
using MiniShopApi.ViewModels;

namespace MiniShopApi.Controllers
{
	[ApiController]
	[Route("products")]
	public class ProductsController : ControllerBase
	{
        private readonly ProductRepository productRepository;

        public ProductsController(ProductRepository productRepository)
		{
            this.productRepository = productRepository;
        }

		[HttpPost]
		public ActionResult<ProductViewModel> CreateProduct(CreateProductViewModel createProductViewModel)
		{
			var newProduct = productRepository.CreateProduct(createProductViewModel.Name, createProductViewModel.Price);

			return Ok(newProduct.MapToViewModel());
		}
	}
}

