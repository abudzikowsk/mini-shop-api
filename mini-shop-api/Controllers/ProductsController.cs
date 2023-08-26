using System;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpGet]
        public ActionResult<List<ProductViewModel>> GetProducts()
        {
	        var result = new List<ProductViewModel>();

	        var products = productRepository.GetAllProducts();

	        foreach (var product in products)
	        {
		        result.Add(product.MapToViewModel());
	        }

	        return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<ProductViewModel> GetProductById(int id)
        {
	        var product = productRepository.GetProductById(id);

	        if (product == null)
	        {
		        return BadRequest();
	        }

	        return Ok(product.MapToViewModel());
        }

		[HttpPost]
		public ActionResult<ProductViewModel> CreateProduct(CreateProductViewModel createProductViewModel)
		{
			var newProduct = productRepository.CreateProduct(createProductViewModel.Name, createProductViewModel.Price);

			return Ok(newProduct.MapToViewModel());
		}

		[HttpPut]
		[Route("{id:int}")]
		public IActionResult UpdateProduct(int id, UpdateProductViewModel updateProductViewModel)
		{ 
			productRepository.UpdateProduct(id ,updateProductViewModel.Name, updateProductViewModel.Price);

			return Ok();
		}
		

		[HttpDelete]
		[Route("{id:int}")]
		public IActionResult DeleteOrder(int id)
		{
			productRepository.DeleteProduct(id);

			return Ok();
		}
	}
}

