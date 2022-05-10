using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
   public interface ICartBL
    {
        public CartModel AddCart(CartModel cartModel, int userId);
        public List<ViewCartModel> GetCartDetailsByUserid(int userId);
      
    }
}
