using ASPCoreFirstApp.Models;
using ASPCoreFirstApp.Services;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace ASPCoreFirstApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsAPIController : ControllerBase
    {
        ProductsDAO repository = new ProductsDAO();
        public ProductsAPIController()
        {
            repository = new ProductsDAO();
        }

        [HttpGet]
        [ResponseType(typeof(List<ProductDTO>))]
        public IEnumerable<ProductDTO> Index()
        {
            List<ProductModel> productList = repository.AllProducts();
            IEnumerable<ProductDTO> productDTOList = from p in productList select new ProductDTO(p.Id, p.Name, p.Price, p.Description);
            return productDTOList;
        }

        [HttpGet("index2")]
        [ResponseType(typeof(List<ProductDTO>))]
        public IEnumerable<ProductDTO> Index2()
        {
            List<ProductModel> productList = repository.AllProducts();
            List<ProductDTO> productDTOList = new List<ProductDTO>();
            foreach(ProductModel p in productList)
            {
                productDTOList.Add(new ProductDTO(p.Id, p.Name, p.Price, p.Description));
            }
            return productDTOList;
        }

        [HttpGet("searchresults/{searchTerm}")]
        [ResponseType(typeof(List<ProductDTO>))]
        public IEnumerable<ProductDTO> SearchResults(string searchTerm)
        {
            List<ProductModel> productlist = repository.SearchProducts(searchTerm);

            // translate into DTO
            List<ProductDTO> productDTOList = new List<ProductDTO>();
            foreach (ProductModel p in productlist)
            {
                productDTOList.Add(new ProductDTO(p.Id, p.Name, p.Price, p.Description));
            }
            return productDTOList;
        }
        [HttpGet("showoneproduct/{Id}")]
        [ResponseType(typeof(ProductDTO))]
        public ActionResult<ProductDTO> ShowOneProduct(int Id)
        {
            ProductModel product = repository.GetProductById(Id);

            ProductDTO productDTO = new ProductDTO(product.Id, product.Name, product.Price, product.Description);
            return productDTO;

        }

        [HttpPut("processedit")]
        [ResponseType(typeof(List<ProductDTO>))]
        public IEnumerable<ProductDTO> ProcessEdit(ProductModel product)
        {
            repository.Update(product);
            List<ProductModel> productlist = repository.AllProducts();
            // translate into DTO
            IEnumerable<ProductDTO> productDTOList = from p in productlist
                                                     select new ProductDTO(p.Id, p.Name, p.Price,
                         p.Description);
            return productDTOList;
        }

        [HttpPut("ProcessEditReturnOneItem")]
        [ResponseType(typeof(ProductDTO))]
        public ActionResult<ProductDTO> ProcessEditReturnOneItem(ProductModel product)
        {
            repository.Update(product);
            ProductModel updatedProduct = repository.GetProductById(product.Id);
            ProductDTO productDTO = new ProductDTO(product.Id, product.Name, product.Price,
                         product.Description);
            return productDTO;
           
        }
    }
}
