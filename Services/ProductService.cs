using ProductApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductApi.Services
{
    public static class ProductService
    {
        private static List<Product> _products = new List<Product>();
        private static int _nextId = 1;

        public static List<Product> GetAll() => _products;

        public static Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public static void Add(Product product)
        {
            product.Id = _nextId++;
            _products.Add(product);
        }

        public static bool Update(int id, Product updatedProduct)
        {
            var existingProduct = GetById(id);
            if (existingProduct == null) return false;

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.Description = updatedProduct.Description;
            return true;
        }

        public static bool Delete(int id)
        {
            var product = GetById(id);
            if (product == null) return false;
            _products.Remove(product);
            return true;
        }

        public static List<Product> SearchByName(string keyword)
        {
            return _products
                .Where(p => p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}