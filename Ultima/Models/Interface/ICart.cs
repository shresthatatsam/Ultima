using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ultima.Models.Interface
{
    public interface ICart
    {
        CartModel Model { get; set; }

        string SaveCart();
        List<CartModel> showalldata();
    }
}