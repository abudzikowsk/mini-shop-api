using System;
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

        public Product GetProductById(int id)
        {
            return applicationDbContext.Products.SingleOrDefault(x => x.Id == id);
        }

        public List<Product> GetAllProducts()
        {
            return applicationDbContext.Products.ToList();
        }

        public Product CreateProduct(string name, decimal price)
        {
            var newProduct = new Product
            {
                Name = name,
                Price = price
            };
            var addedProduct = applicationDbContext.Products.Add(newProduct);
            applicationDbContext.SaveChanges();

            return addedProduct.Entity;
        }

        public void UpdateProduct(int id, string name, decimal? price)
        {
            var productToUpdate = applicationDbContext.Products.SingleOrDefault(x => x.Id == id);

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

            applicationDbContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var productToDelete = applicationDbContext.Products.SingleOrDefault(x => x.Id == id);

            if (productToDelete == null)
            {
                return;
            }

            applicationDbContext.Products.Remove(productToDelete);
            applicationDbContext.SaveChanges();
        }

    }
}

