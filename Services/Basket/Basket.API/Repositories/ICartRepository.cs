using Basket.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetCart(string userName);
        Task<Cart> UpdateCart(Cart cart);
        Task DeleteCart(string userName);
    }
}
