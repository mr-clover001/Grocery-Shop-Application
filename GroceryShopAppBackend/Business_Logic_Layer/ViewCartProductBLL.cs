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
   public  class ViewCartProductBLL
    {
        private Data_Access_Layer.ViewCartProductDAL _DAL;

        private Mapper _ViewCartProductMapper;

        public ViewCartProductBLL()
        {
            _DAL = new Data_Access_Layer.ViewCartProductDAL();

            var _configViewCartProduct = new MapperConfiguration(cfg => cfg.CreateMap<ViewCart, ViewCartDTO>().ReverseMap());
            _ViewCartProductMapper = new Mapper(_configViewCartProduct);
        }

        public List<ViewCartDTO> GetViewCartProducts()
        {
            List<ViewCart> viewCartProductFromDb = _DAL.GetViewCartProducts();
            List<ViewCartDTO> viewCartproductM = _ViewCartProductMapper.Map<List<ViewCart>, List<ViewCartDTO>>(viewCartProductFromDb);
            return viewCartproductM;
        }

        public void AddViewCartProduct(ViewCartDTO ViewCartproductModel)
        {
            ViewCart productEntity = _ViewCartProductMapper.Map<ViewCartDTO, ViewCart>(ViewCartproductModel);
            _DAL.AddViewCartProduct(productEntity);
        }


        public ViewCartDTO GetViewCartProductById(int id)
        {
            var viewCartEntity = _DAL.GetViewCartProductById(id);
            ViewCartDTO viewCartModel = _ViewCartProductMapper.Map<ViewCart, ViewCartDTO>(viewCartEntity);

            return viewCartModel;
        }

        public ViewCartDTO GetViewCartProductByName(string productName)
        {
            var viewCartEntity = _DAL.GetViewCartProductByName(productName);
            ViewCartDTO viewCartModel = _ViewCartProductMapper.Map<ViewCart, ViewCartDTO>(viewCartEntity);

            return viewCartModel;
        }


        public void DeleteViewCartProduct(string productName)
        {
           _DAL.DeleteViewCartProduct(productName);
        }

        public void DeleteAllViewCartProducts()
        {
            _DAL.DeleteAllViewCartProducts();
        }


        public ViewCartDTO AddQuantity(int id)
        {
            var viewCartEntity = _DAL.AddQuantity(id);
            var viewCartModel = _ViewCartProductMapper.Map<ViewCart, ViewCartDTO>(viewCartEntity);

            return viewCartModel;
        }

        public ViewCartDTO DecreaseQuantity(int id)
        {
            var viewCartEntity = _DAL.DecreaseQuantity(id);
            var viewCartModel = _ViewCartProductMapper.Map<ViewCart, ViewCartDTO>(viewCartEntity);

            return viewCartModel;
        }

   


    }
}
