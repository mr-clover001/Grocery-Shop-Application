using Data_Access_Layer.Repository.Entities;
using GroceryShopApp.Repository;
using GroceryShopApp.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Data_Access_Layer
{
    public class ViewCartProductDAL
    {

        public List<ViewCart> GetViewCartProducts()
        {
            var db = new ProductDbContext();
            return db.ViewCart.ToList();
        }

        public void AddViewCartProduct(ViewCart viewChartProduct)
        {
            
            var db = new ProductDbContext();
            db.ViewCart.Add(viewChartProduct);
            db.SaveChanges();
        }

        public ViewCart GetViewCartProductById(int id)
        {
            var db = new ProductDbContext();
            ViewCart viewCart = new ViewCart();

            viewCart = db.ViewCart.FirstOrDefault(x => x.Id == id);

            return viewCart;
        }

        public ViewCart GetViewCartProductByName(string productName)
        {
            var db = new ProductDbContext();
            ViewCart viewCart = new ViewCart();

            viewCart = db.ViewCart.FirstOrDefault(x => x.ProductName == productName);

            return viewCart;
        }


        public void DeleteViewCartProduct(string productName)
        {
            var db = new ProductDbContext();
            var viewCart = db.ViewCart.FirstOrDefault(x => x.ProductName == productName);

            if (viewCart != null)
            {
                db.ViewCart.Remove(viewCart);
                db.SaveChanges();
            }


        }

        public void DeleteAllViewCartProducts()
        {
            var db = new ProductDbContext();
            var viewCartProducts = db.ViewCart.ToList();

            if (viewCartProducts.Any())
            {
                db.ViewCart.RemoveRange(viewCartProducts);
                db.SaveChanges();
            }
        }

        public ViewCart AddQuantity(int id)
        {
            var db = new ProductDbContext();
            var viewCart = db.ViewCart.FirstOrDefault(x => x.Id == id);

            if (viewCart != null)
            {
                viewCart.Quantity++;
                db.SaveChanges();
            }

            return viewCart;
        }

        public ViewCart DecreaseQuantity(int id)
        {
            var db = new ProductDbContext();
            var viewCart = db.ViewCart.FirstOrDefault(x => x.Id == id);

            if (viewCart != null)
            {
                viewCart.Quantity--;
                db.SaveChanges();
            }

            return viewCart;
        }


      


    }
}
