using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Managers
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;

        public ProductManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            var products = _manager.ProductRepo.GetAllProducts(trackChanges);

            if(products is null)
            {
                throw new Exception("Products Not Found.");
            }
            
            return products;
        }

        public Product GetProductById(int productId, bool trackChanges)
        {
            var product = _manager.ProductRepo.GetProductById(productId, trackChanges);

            if(product is null)
            {
                throw new Exception($"Product With {productId} ID Not Found.");
            }

            return product;
        }
    }
}