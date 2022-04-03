using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreFirstApp.Models
{
    public class ProductModel
    {
        [DisplayName("Product ID")]
        public int Id { get; set; }
        [DisplayName("Product Name")]
        public string Name { get; set; }

        [DisplayName("Price Per Ton")]
        public decimal Price { get; set; }

        [DisplayName("Product Description")]
        public string Description { get; set; }

        public ProductModel(int id, string name, decimal price, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }

        public ProductModel()
        {
        }
    }
}
