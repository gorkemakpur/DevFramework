using DevFramework.Core.Utilities.Mapping;
using DevFramework.Northwind.Business.Concrete.Managers;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFramework.Northwind.Business.Tests
{

    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()
        {
        //    Mock<IProductDal> mock = new Mock<IProductDal>();
        //    ProductManager productManager = new ProductManager(mock.Object,A);

        //    productManager.Add(new Product());
        }
    }
}
