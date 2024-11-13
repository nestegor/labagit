using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManage
{
    public class ProductManager
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void UpdatePrice(string productName, float newPrice)
        {
            var product = products.Find(p => p.Name == productName);
            if (product != null && newPrice >= 0)
            {
                product.Price = newPrice;
            }
            else
            {
                throw new ArgumentException("Product not found or invalid price");
            }
        }

        public void SellProduct(string productName, int quantity)
        {
            var product = products.Find(p => p.Name == productName);
            if (product != null)
            {
                if (product.Stock >= quantity)
                {
                    product.Stock -= quantity;
                }
                else
                {
                    throw new InvalidOperationException("Not enough stock to sell");
                }
            }
            else
            {
                throw new ArgumentException("Product not found");
            }
        }

        public Product GetProduct(string productName)
        {
            var product = products.Find(p => p.Name == productName);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new ArgumentException("Product not found");
            }
        }
    }
}
