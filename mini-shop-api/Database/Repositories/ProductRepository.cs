using System;
using Microsoft.EntityFrameworkCore;
using MiniShopApi.Database.Entitites;

namespace MiniShopApi.Database.Repositories
{
	public class ProductRepository
	{
        private readonly ApplicationDbContext applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
		{
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await applicationDbContext.Products.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await applicationDbContext.Products.ToListAsync();
        }

        public async Task<Product> CreateProduct(string name, decimal price)
        {
            var newProduct = new Product
            {
                Name = name,
                Price = price
            };
            var addedProduct = applicationDbContext.Products.Add(newProduct);
            await applicationDbContext.SaveChangesAsync();

            return addedProduct.Entity;
        }

        public async Task UpdateProduct(int id, string name, decimal? price)
        {
            var productToUpdate = await applicationDbContext.Products.SingleOrDefaultAsync(x => x.Id == id);

            if (productToUpdate == null)
            {
                return;
            }

            if (name != null)
            {
                productToUpdate.Name = name;
            }

            if (price.HasValue)
            {
                productToUpdate.Price = price.Value;

            }

            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var productToDelete = applicationDbContext.Products.SingleOrDefault(x => x.Id == id);

            if (productToDelete == null)
            {
                return;
            }

            applicationDbContext.Products.Remove(productToDelete);
            await applicationDbContext.SaveChangesAsync();
        }

    }
}

