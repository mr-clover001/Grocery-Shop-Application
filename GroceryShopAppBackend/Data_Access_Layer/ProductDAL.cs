using GroceryShopApp.Repository;
using GroceryShopApp.Repository.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;




namespace Data_Access_Layer
{
    public class ProductDAL
    {
      

        public List<Products> GetProductDetails()
        {
            var db = new ProductDbContext();
            return db.Products.ToList();
        }

        public Products GetProductDetailById(int id)
        {
            var db = new ProductDbContext();
            Products product = new Products();

            product = db.Products.FirstOrDefault(x => x.Id == id);

            return product;
        }

        
        public Products UpdateProduct(Products product)
                {
                    using (var db = new ProductDbContext())
                    {

                        var existingProduct = db.Products.Find(product.Id);

                        if (existingProduct != null)
                        {
                            // Update the properties of the existing product with the new values
                            existingProduct.ProductName = product.ProductName;
                            existingProduct.Description = product.Description;
                            existingProduct.Quantity = product.Quantity;
                            existingProduct.ImageFileName = product.ImageFileName;
                            existingProduct.Price = product.Price;
                            existingProduct.Discount = product.Discount;
                            existingProduct.Specification = product.Specification;
                            existingProduct.AvaiableQuantity = product.AvaiableQuantity;
                            existingProduct.Category = product.Category;

                    // Save the changes to the database
                    db.SaveChanges();



                            return existingProduct;

                        }
                    }

                    return null;
                } 
       

        public void AddProduct(Products product)
        {
            var db = new ProductDbContext();
            db.Add(product);
            db.SaveChanges();
        }


        public void DeleteProduct(int id)
        {
            var db = new ProductDbContext();
            var product = db.Products.FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }


        public Products AddQuantity(int id)
        {
            var db = new ProductDbContext();
            var productEntity = db.Products.FirstOrDefault(x => x.Id == id);

            if (productEntity != null)
            {
                productEntity.Quantity++;
                db.SaveChanges();
            }

            return productEntity;
        }

        public Products DecreaseQuantity(int id)
        {
            var db = new ProductDbContext();
            var productEntity = db.Products.FirstOrDefault(x => x.Id == id);

            if (productEntity != null)
            {
                productEntity.Quantity--;
                db.SaveChanges();
            }

            return productEntity;
        }



    }
}
