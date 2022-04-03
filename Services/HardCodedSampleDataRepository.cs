using ASPCoreFirstApp.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreFirstApp.Services
{
    public class HardCodedSampleDataRepository : IProductsDataService
    {
        static List<ProductModel> productList;
        public HardCodedSampleDataRepository()
        {
            productList = new List<ProductModel>();
            productList.Add(new ProductModel(1, "Apache Brown m", 16.5m, "3/8 inch minus"));
            productList.Add(new ProductModel(2, "Superior Gold m", 15.5m, "7/8 inch Screened"));
            productList.Add(new ProductModel(1, "Apache Brown lg", 14.5m, "2-4 inch rip rap"));
            productList.Add(new ProductModel(2, "Superior Gold lg", 17.5m, "2 inch"));

            for (int i = 0; i < 100; i++)
            {
                productList.Add(new Faker<ProductModel>()
                    .RuleFor(p => p.Id, i + 5)
                    .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                    .RuleFor(p => p.Price, f => f.Random.Decimal(100))
                    .RuleFor(p => p.Description, f => f.Rant.Review())
                    );
            }
        }
        public List<ProductModel> AllProducts()
        {
            return productList;
        }

        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public ProductModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
