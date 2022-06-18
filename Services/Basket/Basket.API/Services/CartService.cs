using AutoMapper;
using Basket.API.Entities;
using Basket.API.Repositories;
using EventBus.Messages.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Services
{
    public class CartService : ICartService
    {

        private readonly ICartRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public CartService(ICartRepository repository, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        public async Task Checkout(CartCheckout cartCheckout)
        {
            var cart = await _repository.GetCart(cartCheckout.UserName);
            if (cart == null)
            {
                throw new Exception();
            }

            // send checkout event to rabbitmq
            var eventMessage = _mapper.Map<BasketCheckoutEvent>(cartCheckout);
            eventMessage.TotalPrice = cart.TotalPrice;
            await _publishEndpoint.Publish(eventMessage);

            // remove the basket
            await _repository.DeleteCart(cart.UserName);
        }

        public async Task DeleteCart(string userName)
        {
            await _repository.DeleteCart(userName); 
        }

        public async Task<Cart> GetCart(string userName)
        {
            return await _repository.GetCart(userName);
        }

        public async Task<Cart> UpdateCart(Cart cart)
        {
            return await _repository.UpdateCart(cart)
        }
    }
}
