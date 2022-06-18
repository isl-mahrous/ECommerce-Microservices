using Basket.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Services
{
    public interface ICartService
    {
        Task<Cart> GetCart(string userName);
        Task<Cart> UpdateCart(Cart cart);
        Task DeleteCart(string userName);
        Task Checkout(CartCheckout cartCheckout);
    }
}
