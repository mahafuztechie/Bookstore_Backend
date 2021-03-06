using BusinessLayer.Interface;
using CommonLayer.Models;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class CartBL : ICartBL
    {
        private readonly ICartRL cartRL;
        public CartBL(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }
        public CartModel AddCart(CartModel cartModel, int userId)
        {
            try
            {
                return this.cartRL.AddCart(cartModel, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public CartModel UpdateCart(int cartId, CartModel cartModel, int userId)
        {
            try
            {
                return this.cartRL.UpdateCart(cartId, cartModel, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool DeleteCart(int cartId, int userId)
        {
            try
            {
                return this.cartRL.DeleteCart(cartId, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<ViewCartModel> GetCartDetailsByUserid(int userId)
        {
            try
            {
                return this.cartRL.GetCartDetailsByUserid(userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
