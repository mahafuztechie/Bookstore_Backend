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
     
    }
}
