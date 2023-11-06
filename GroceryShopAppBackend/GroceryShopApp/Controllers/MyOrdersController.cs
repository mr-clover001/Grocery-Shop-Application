using GroceryShopApp.Repository;
using GroceryShopApp.Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Business_Logic_Layer.ModelsDTO;
using Microsoft.AspNetCore.Cors;
using System;

namespace GroceryShop.API.Controllers
{


    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class MyOrdersController : ControllerBase
    {

        private Business_Logic_Layer.MyOrdersProductsBLL _BLL;

        public MyOrdersController()
        {
            _BLL = new Business_Logic_Layer.MyOrdersProductsBLL();
        }


        [Route("MyOrders")]
        [HttpGet]
        public List<MyOrdersDTO> GetMyOrdersProducts()
        {
            return _BLL.GetMyOrdersProducts();
        }


        [HttpPost]
        [Route("PlaceOrder")]
        public IActionResult MyOrdersProducts([FromBody] List<ViewCart> viewCartProducts)
        {
            try
            {
                _BLL.MyOrdersProducts(viewCartProducts);
                return Ok(new { message = "ViewCart products added to MyOrder successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Error occurred while adding ViewCart products to MyOrder: " + ex.Message });
            }
        }

        [Route("DeleteAllMyOrdersProducts")]
        [HttpDelete]
        public IActionResult DeleteAllMyOrderCartProducts()
        {
            _BLL.DeleteAllMyOrderCartProducts();

            return NoContent();
        }

    }
}
