using DependencyInjection_WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SalesController : ControllerBase
    {
        private readonly IDiscount _discount;

        public SalesController(IDiscount discount)
        {
            _discount = discount;
           
           
        }

        [HttpGet]
        public IActionResult GetDiscount(int amount)
        {
            int discountAmount = _discount.DiscountAmount(amount);
            return Ok(new { OriginalAmount = amount, DiscountAmount = discountAmount, FinalAmount = amount - discountAmount });
            //return Ok(new
            //{
            //    service1 = _discount.GetId(),
            //    service2=_discount1.GetId()
            //});



        }
        

    }
}
