using GroceryShopApp.Repository;
using GroceryShopApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business_Logic_Layer.ModelsDTO;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Business_Logic_Layer
{
    public class ProductBLL
    {

        private Data_Access_Layer.ProductDAL _DAL;
        private Mapper _ProductMapper;
       

        public ProductBLL()
        {
            _DAL = new Data_Access_Layer.ProductDAL();

            var _configProduct = new MapperConfiguration(cfg => cfg.CreateMap<Products, ProductsDTO>().ReverseMap());
            _ProductMapper = new Mapper(_configProduct);

          


        }

        public List<ProductsDTO> GetProductDetails()
        {
            List<Products> productFromDb = _DAL.GetProductDetails();
            List<ProductsDTO> productM = _ProductMapper.Map<List<Products>, List<ProductsDTO>>(productFromDb);
            return productM;
        }

        

        public ProductsDTO GetProductDetailById(int id)
        {
            var productEntity = _DAL.GetProductDetailById(id);
            ProductsDTO productModel = _ProductMapper.Map< Products , ProductsDTO >( productEntity);

            return productModel;
        }
       
          
        public ProductsDTO UpdateProduct(int id, ProductsDTO updatedProduct)
                {
                    ProductsDTO productDTO = GetProductDetailById(id);
                    Products productEntity = _ProductMapper.Map<ProductsDTO, Products>(productDTO);

                    if (productEntity != null)
                    {
                // Update the retrieved product with the new values
                productEntity.ProductName = updatedProduct.ProductName;
                productEntity.Description = updatedProduct.Description;
                productEntity.Quantity = updatedProduct.Quantity;
                productEntity.ImageFileName = updatedProduct.ImageFileName;
                productEntity.Price = updatedProduct.Price;
                productEntity.Discount = updatedProduct.Discount;
                productEntity.Specification = updatedProduct.Specification;
                productEntity.AvaiableQuantity = updatedProduct.AvaiableQuantity;
                productEntity.Category = updatedProduct.Category;


                var data = _DAL.UpdateProduct(productEntity);
                        ProductsDTO productM = _ProductMapper.Map<Products, ProductsDTO>(data);
                return productM;
            }

                    return null;
                }

           


   
        public void AddProduct(ProductsDTO productDTO)
        {
            Products productEntity = _ProductMapper.Map<ProductsDTO, Products>(productDTO);
           _DAL.AddProduct(productEntity);
        }


        public void DeleteProduct(int id)
        {
            _DAL.DeleteProduct(id);

        }


        public ProductsDTO AddQuantity(int id)
        {

            var viewCartEntity = _DAL.AddQuantity(id);
            var viewCartDTO = _ProductMapper.Map<Products, ProductsDTO>(viewCartEntity);

            return viewCartDTO;
        }

        public ProductsDTO DecreaseQuantity(int id)
        {
            var viewCartEntity = _DAL.DecreaseQuantity(id);
            var viewCartDTO = _ProductMapper.Map<Products, ProductsDTO>(viewCartEntity);

            return viewCartDTO;
        }



    }
}
