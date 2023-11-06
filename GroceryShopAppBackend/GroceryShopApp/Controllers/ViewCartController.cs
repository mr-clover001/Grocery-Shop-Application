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

    public class ViewCartController : ControllerBase

    {
        private Business_Logic_Layer.ViewCartProductBLL _BLL;

        public ViewCartController()
        {
            _BLL = new Business_Logic_Layer.ViewCartProductBLL();
        }


        [Route("ViewCart")]
        [HttpGet]
        public List<ViewCartDTO> GetViewCartProducts()
        {
            return _BLL.GetViewCartProducts();
        }


        [HttpGet]
        [Route("ViewCartProductDetail")]
        public ActionResult<ViewCartDTO> GetViewCartProductById(int id)
        {
            var data = _BLL.GetViewCartProductById(id);

            if (data == null)
            {
                return NotFound("Invalid ID");
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ViewCartProductDetail")]
        public ActionResult<ViewCartDTO> GetViewCartProductByName(string productName)
        {
            var data = _BLL.GetViewCartProductByName(productName);

            if (data == null)
            {
                return NotFound("Invalid ID");
            }

            return Ok(data);
        }


        [Route("AddToViewCart")]
        [HttpPost]
        public void AddViewCartProduct([FromBody] ViewCartDTO ViewCartModel)
        {
            _BLL.AddViewCartProduct(ViewCartModel);
        }


        [Route("DeleteViewCartProduct")]
        [HttpDelete]
        public IActionResult DeleteViewCartProduct(string productName)
        {
           
            var viewCart = _BLL.GetViewCartProductByName(productName);

            if (viewCart == null)
            {
                return NotFound("Invalid ID");
            }

            _BLL.DeleteViewCartProduct(productName);

            return NoContent();
        }

        [Route("DeleteAllViewCartProducts")]
        [HttpDelete]
        public IActionResult DeleteAllViewCartProducts()
        {
            _BLL.DeleteAllViewCartProducts();

            return NoContent();
        }


        [HttpPut]
        [Route("AddQuantity")]
        public ActionResult<ViewCartDTO> AddQuantity([FromBody] ViewCartDTO viewCartModel)
        {
            var data = _BLL.AddQuantity(viewCartModel.Id);

            if (data == null)
            {
                return NotFound("Invalid ID");
            }

            return Ok(data);
        }

        [HttpPut]
        [Route("DecreaseQuantity")]
        public ActionResult<ViewCartDTO> DecreaseQuantity([FromBody] ViewCartDTO viewCartModel)
        {
            var data = _BLL.DecreaseQuantity(viewCartModel.Id);

            if (data == null)
            {
                return NotFound("Invalid ID");
            }

            return Ok(data);
        }


    }
}
