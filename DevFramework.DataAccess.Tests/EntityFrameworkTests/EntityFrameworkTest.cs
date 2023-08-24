using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFramework.Northwind.DataAccess.Tests.EntityFrameworkTests
{

    [TestClass]
    public class EntityFrameworkTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            EfProductDal productDal = new EfProductDal();
            var results = productDal.GetList();

            Assert.AreEqual(80, results.Count);

        }



        [TestMethod]
        public void Get_all_with_parameters_returns_filtered_products()
        {
            EfProductDal productDal = new EfProductDal();

            var results = productDal.GetList(p=>p.ProductName.Contains("ab"));

            Assert.AreEqual(4, results.Count);

        }




    }
}
