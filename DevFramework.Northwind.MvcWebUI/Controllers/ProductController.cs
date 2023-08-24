using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var model = new ProductListViewModel()
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }



        public string Add()
        {
            _productService.Add(new Product()
            {
                ProductName = "GSM",
                CategoryId = 1,
                QuantityPerUnit = "1",
                UnitPrice = 25,

            });
            return "added";
        }

        public string AddUpdate()
        {
            _productService.TransactionalOperation(
            new Product(){
                ProductName = "ssssssssssssssssssss",
                CategoryId = 1,
                QuantityPerUnit = "1",
                UnitPrice = 25,

            },
            new Product(){

                ProductName = "qqqqqqqqqqqqqqqqqqq",
                CategoryId = 1,
                QuantityPerUnit = "1",
                UnitPrice = 1,
                ProductId=1
            });



            return "Done";
        }

    }
}