using NUnit.Framework;
using ProductManage;
using System;

namespace ProductManageTests
{
    [TestFixture]
    public class ProductTest
    {
        [Test]
        public void Product_Should_Init_Correctly()
        {
            var product = new Product("Laptop", 1000, 10);

            Assert.AreEqual("Laptop", product.Name);
            Assert.AreEqual(1000, product.Price);
            Assert.AreEqual(10, product.Stock);
        }
    }
}
