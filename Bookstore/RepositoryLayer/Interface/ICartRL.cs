using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICartRL
    {
        public CartModel AddCart(CartModel cartModel, int userId);
        public List<ViewCartModel> GetCartDetailsByUserid(int userId);
        public CartModel UpdateCart(int cartId, CartModel cartModel, int userId);
        public bool DeleteCart(int cartId, int userId);

    }
}
