using ASPCoreFirstApp.Models;
using ASPCoreFirstApp.Services;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreFirstApp.Controllers
{
    public class ProductsController : Controller
    {
        ProductsDAO repository = new ProductsDAO();
        public ProductsController()
        {
            repository = new ProductsDAO();
        }

        public IActionResult Index()
        {
            return View(repository.AllProducts());
        }

        public IActionResult SearchResult(string search)
        {
            List<ProductModel> productList = repository.SearchProducts(search);
            return View("Index", productList);
        }

        public IActionResult DeleteOne(int id)
        {
            ProductsDAO productDAO = new ProductsDAO();
            ProductModel product = productDAO.GetProductById(id);
            productDAO.Delete(product);
            return View("Index", productDAO.AllProducts());
        }

        public IActionResult SearchForm()
        {
            return View();
        }

        public IActionResult ShowOneProduct(int id)
        {
            return View("ShowOneProduct",repository.GetProductById(id));
        }

        public IActionResult ShowOneProductJSON(int id)
        {
            return Json(repository.GetProductById(id));
        }

        public IActionResult ShowEditForm(int id)
        {
            return View(repository.GetProductById(id));
        }
        public IActionResult ProcessEdit(ProductModel product)
        {
            repository.Update(product);
            return View("Index", repository.AllProducts());
        }
        public IActionResult ProcessEditReturnPartial(ProductModel product)
        {
            repository.Update(product);
            return PartialView("_productCard", product);
        }

    }
}
