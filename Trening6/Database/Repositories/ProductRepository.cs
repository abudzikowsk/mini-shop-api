using System;
using Trening6.Database.Entitites;

namespace Trening6.Database.Repositories
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

        public void CreateProduct(string name, decimal price)
        {
            var newProduct = new Product
            {
                Name = name,
                Price = price
            };
            applicationDbContext.Products.Add(newProduct);
            applicationDbContext.SaveChanges();
        }

        public void ProductToUpdate(int id, string name, decimal price)
        {
            var productToUpdate = applicationDbContext.Products.SingleOrDefault(x => x.Id == id);

            if (productToUpdate == null)
            {
                return;
            }

            productToUpdate.Name = name;
            productToUpdate.Price = price;

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

