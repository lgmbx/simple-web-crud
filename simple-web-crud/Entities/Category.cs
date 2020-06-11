using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace simple_web_crud.Entities {
    public class Category   {

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Product> ProductsList { get; set; } = new List<Product>();

        public Category() {
        }

        public void AddProduct(Product product) {
            ProductsList.Add(product);
        }



    }
}