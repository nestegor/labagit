using NUnit.Framework;
using ProductManage;
using System;

namespace ProductManageTests
{
    [TestFixture]
    public class ProductManagerTest
    {
        private ProductManager manager;

        [SetUp]
        public void Setup()
        {
            // Указываем все параметры для создания Product
            manager = new ProductManager();
            manager.AddProduct(new Product("Laptop", 1000, 10));
        }

        [Test]
        public void AddProduct_Should_Add_Product_To_List()
        {
            // Указываем все параметры для создания Product
            var product = new Product("Phone", 500, 20);
            manager.AddProduct(product);

            Assert.That(manager.GetProduct("Phone"), Is.EqualTo(product));
        }

        [Test]
        public void UpdatePrice_Should_Change_Product_Price()
        {
            manager.UpdatePrice("Laptop", 1200);
            var updatedProduct = manager.GetProduct("Laptop");

            Assert.That(updatedProduct.Price, Is.EqualTo(1200));
        }

        [Test]
        public void UpdatePrice_Should_Throw_On_Invalid_Price()
        {
            Assert.Throws<ArgumentException>(() => manager.UpdatePrice("Laptop", -100));
        }

        [Test]
        public void SellProduct_Should_Decrease_Stock()
        {
            manager.SellProduct("Laptop", 3);
            var product = manager.GetProduct("Laptop");

            Assert.That(product.Stock, Is.EqualTo(7));
        }

        [Test]
        public void SellProduct_Should_Throw_On_Insufficient_Stock()
        {
            Assert.Throws<InvalidOperationException>(() => manager.SellProduct("Laptop", 15));
        }

        [Test]
        public void GetProduct_Should_Return_Correct_Product()
        {
            var product = manager.GetProduct("Laptop");
            Assert.That(product.Name, Is.EqualTo("Laptop"));
            Assert.That(product.Price, Is.EqualTo(1000));
            Assert.That(product.Stock, Is.EqualTo(10));
        }

        [Test]
        public void GetProduct_Should_Throw_On_Invalid_Product()
        {
            Assert.Throws<ArgumentException>(() => manager.GetProduct("Tablet"));
        }
    }
}
