using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _baseketRepository;
        private readonly IMapper _mapper;
        public BasketController(IBasketRepository baseketRepository, IMapper mapper)
        {
            _mapper = mapper;
            _baseketRepository = baseketRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _baseketRepository.GetBasketAsync(id);

            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
        {
            var CustomerBasket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basket);
            
            var updatedBasket = await _baseketRepository.UpdateBasketAsync(CustomerBasket);

            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await _baseketRepository.DeleteBasketAsync(id);
        }
    }
}