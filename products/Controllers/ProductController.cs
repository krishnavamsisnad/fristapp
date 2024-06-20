using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products.Data;
using products.Models;
using System.Collections.Generic;
using System.Linq;

namespace products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext dbContext;

        public ProductController(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public List<Products> Getall()
        {
            return dbContext.Products.ToList();
        }

        [HttpPost]
        public Products Creatprodouct(Products products)
        {
            dbContext.Products.Add(products);
            dbContext.SaveChanges(); // Save changes to the database
            return products; // Return the newly created product
        }

        [HttpPut("{id}")]
        public Products UpdateProducts(int id, Products updatedProduct)
        {
            var existingProduct = dbContext.Products.Find(id);

            if (existingProduct != null)
            {
                existingProduct.ProductName = updatedProduct.ProductName;
                existingProduct.Price = updatedProduct.Price;

                dbContext.Products.Update(existingProduct);
                dbContext.SaveChanges(); // Save changes to the database

                return existingProduct; // Return the updated product
            }
            else
            {
                return null;
            }
        }
    }
}
