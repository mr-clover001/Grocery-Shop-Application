using Data_Access_Layer.Repository.Entities;
using GroceryShopApp.Repository;
using GroceryShopApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Access_Layer
{
    public class MyOrdersProductsDAL
    {

        public List<MyOrders> GetMyOrdersProducts()
        {
            var db = new ProductDbContext();
            return db.MyOrders.ToList();
        }


        public void MyOrdersProducts(List<ViewCart> viewCartProducts)
        {
            var db = new ProductDbContext();

            foreach (var viewCartProduct in viewCartProducts)
            {

                MyOrders myOrders = new MyOrders();


                myOrders.ProductName = viewCartProduct.ProductName;
                myOrders.Description = viewCartProduct.Description;
                myOrders.Quantity = viewCartProduct.Quantity;
                myOrders.ImageFileName = viewCartProduct.ImageFileName;
                myOrders.Price = viewCartProduct.Price;
                myOrders.Discount = viewCartProduct.Discount;
                myOrders.Specification = viewCartProduct.Specification;
                myOrders.AvaiableQuantity = viewCartProduct.AvaiableQuantity;
                myOrders.Category = viewCartProduct.Category;


                db.MyOrders.Add(myOrders);
            }


            db.SaveChanges();
        }

        public void DeleteAllMyOrderCartProducts()
        {
            var db = new ProductDbContext();
            var myOrderProducts = db.MyOrders.ToList();

            if (myOrderProducts.Any())
            {
                db.MyOrders.RemoveRange(myOrderProducts);
                db.SaveChanges();
            }
        }


    }
}
