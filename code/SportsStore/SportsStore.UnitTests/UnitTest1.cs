﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            //准备
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product { ProductID=1,Name="P1"},
                new Product { ProductID=2,Name="P2"},
                new Product { ProductID=3,Name="P3"},
                new Product { ProductID=4,Name="P4"},
                new Product { ProductID=5,Name="P5"}
            });
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //动作
            IEnumerable<Product> result = (IEnumerable<Product>)controller.List(2).Model;

            //断言
            Product[] prodarray = result.ToArray();
            Assert.IsTrue(prodarray.Length==2);
            Assert.AreEqual(prodarray[0].Name,"P4");
            Assert.AreEqual(prodarray[1].Name,"P5");
        }
    }
}
