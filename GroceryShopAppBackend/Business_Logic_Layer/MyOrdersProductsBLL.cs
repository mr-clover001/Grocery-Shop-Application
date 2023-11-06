using GroceryShopApp.Repository;
using GroceryShopApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business_Logic_Layer.ModelsDTO;
using Data_Access_Layer.Repository.Entities;

namespace Business_Logic_Layer
{
    public class MyOrdersProductsBLL
    {
        private Data_Access_Layer.MyOrdersProductsDAL _DAL;

        private Mapper _MyOrdersProductMapper;

        public MyOrdersProductsBLL()
        {
            _DAL = new Data_Access_Layer.MyOrdersProductsDAL();

            var _configMyOrdersProduct = new MapperConfiguration(cfg => cfg.CreateMap<MyOrders, MyOrdersDTO>().ReverseMap());
            _MyOrdersProductMapper = new Mapper(_configMyOrdersProduct);
        }


        // MyOrders

        public List<MyOrdersDTO> GetMyOrdersProducts()
        {
            List<MyOrders> MyOrdersProductFromDb = _DAL.GetMyOrdersProducts();
            List<MyOrdersDTO> MyOrdersproductM = _MyOrdersProductMapper.Map<List<MyOrders>, List<MyOrdersDTO>>(MyOrdersProductFromDb);
            return MyOrdersproductM;
        }


        public void MyOrdersProducts(List<ViewCart> viewCartProducts)
        {

            _DAL.MyOrdersProducts(viewCartProducts);

        }

        public void DeleteAllMyOrderCartProducts()
        {
            _DAL.DeleteAllMyOrderCartProducts();
        }


      
    }
}
