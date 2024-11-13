using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductManage
{
    public static class ProductUtilities
    {
        // Метод для применения скидки на цену продукта
        public static float ApplyDiscount(Product product, float discountPercent)
        {
            if (discountPercent < 0 || discountPercent > 100)
            {
                throw new ArgumentException("Discount percent must be between 0 and 100.");
            }
            return product.Price - (product.Price * (discountPercent / 100));
        }

        // Метод для получения продуктов, имеющих меньше определенного количества на складе
        public static List<Product> GetLowStockProducts(List<Product> products, int threshold)
        {
            return products.Where(p => p.Stock < threshold).ToList();
        }

        // Метод для расчета общей стоимости всех товаров в списке продуктов
        public static float CalculateTotalInventoryValue(List<Product> products)
        {
            return products.Sum(p => p.Price * p.Stock);
        }

        // Метод для получения списка продуктов по определенной ценовой категории
        public static List<Product> GetProductsByPriceRange(List<Product> products, float minPrice, float maxPrice)
        {
            return products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
        }

        // Метод для увеличения запаса продукта на складе
        public static void RestockProduct(Product product, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity to restock must be greater than zero.");
            }
            product.Stock += quantity;
        }
    }
}
