﻿using BusinessLayer.Interface;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartBL cartBL;

        public CartController(ICartBL cartBL)
        {
            this.cartBL = cartBL;
        }
        //addcart api calling
        [HttpPost("Add")]
        public IActionResult AddCart(CartModel cart)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "Id").Value);
                var cartdetails = this.cartBL.AddCart(cart, userId);
                if (cartdetails != null)
                {
                    return this.Ok(new { Success = true, message = " Sucessfully Book Added in Cart", Response = cartdetails });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "failed to book in cart" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpPut("Update/{cart_Id}")]
        public IActionResult UpdateCart(int cart_Id, CartModel cartModel)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "Id").Value);
                var cart = this.cartBL.UpdateCart(cart_Id, cartModel, userId);
                if (cart != null)
                {
                    return this.Ok(new { Success = true, message = "Cart Updated successfully", Response = cart });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "failed to update cart" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        //delete
        [HttpDelete("Delete/{cart_Id}")]
        public IActionResult DeletCart(int cart_Id)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "Id").Value);
                if (this.cartBL.DeleteCart(cart_Id, userId))

                {
                    return this.Ok(new { Success = true, message = "Cart Deleted Sucessfully" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "failed dto delete cart" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpGet("Get")]
        public IActionResult GetCartDetailsByUserid()
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "Id").Value);
                var cartdetails = this.cartBL.GetCartDetailsByUserid(userId);
                if (cartdetails != null)
                {
                    return this.Ok(new { Success = true, message = "cart Details Fetched successfully", Response = cartdetails });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "failed to fetch cart details" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
       
    }
}
