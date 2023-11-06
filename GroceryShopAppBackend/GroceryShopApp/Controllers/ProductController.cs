

using GroceryShopApp.Repository;
using GroceryShopApp.Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Business_Logic_Layer.ModelsDTO;
using Microsoft.AspNetCore.Cors;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace GroceryShopApp.Controllers
{

    [ApiController] 
    [Route("[controller]")]

    [EnableCors("AllowSpecificOrigin")]

    public class ProductController : ControllerBase
    {

        private Business_Logic_Layer.ProductBLL _BLL;

        public ProductController()
        {
            _BLL = new Business_Logic_Layer.ProductBLL();
            
        }

         [HttpGet]
         [Route("ProductDetails")]
         public List<ProductsDTO> GetProductDetails()
        {
            return _BLL.GetProductDetails();
        }

        [HttpGet]
        [Route("ProductDetail")]
        public ActionResult<ProductsDTO> GetProductDetailById(int id)
        {
           var data = _BLL.GetProductDetailById(id);

            if(data ==null)
            {
                return NotFound("Invalid ID");
            }

            return Ok(data);
        }

        [Route("AddProduct")]
        [HttpPost]
        public void AddProduct([FromBody] ProductsDTO productDTO)
        {
            ProductsDTO productDetail = new ProductsDTO();
            productDetail.ImageFileName = productDTO.ImageFileName;
            _BLL.AddProduct(productDTO);
        }

    

        [Route("UpdateProduct")]
        [HttpPut]
        public ActionResult UpdateProduct(int id, ProductsDTO updatedProduct)
           {
               var result = _BLL.UpdateProduct(id, updatedProduct);

               if (result != null)
               {
                   return Ok("successfully update");
               }
               else
               {
                   return NotFound("Failed to update");
               }
           }
         


        [Route("DeleteProduct")]
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var product = _BLL.GetProductDetailById(id);

            if (product == null)
            {
                return NotFound("Invalid ID");
            }

            _BLL.DeleteProduct(id);

            return NoContent();
        }


        [Route("AddQuantity")]
        [HttpPut]
        public ActionResult<ProductsDTO> AddQuantity([FromBody] ProductsDTO productDTO)
        {
            var data = _BLL.AddQuantity(productDTO.Id);

            if (data == null)
            {
                return NotFound("Invalid ID");
            }

            return Ok(data);
        }

        [HttpPut]
        [Route("DecreaseQuantity")]
        public ActionResult<ProductsDTO> DecreaseQuantity([FromBody] ProductsDTO productDTO)
        {
            var data = _BLL.DecreaseQuantity(productDTO.Id);

            if (data == null)
            {
                return NotFound("Invalid ID");
            }

            return Ok(data);
        }




    }
}
