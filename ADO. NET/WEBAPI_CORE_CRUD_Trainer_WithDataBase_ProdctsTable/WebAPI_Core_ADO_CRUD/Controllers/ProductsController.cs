using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Core_ADO_CRUD.Models;

namespace WebAPI_Core_ADO_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductData _data;

        public ProductsController(ProductData data)
        {
            _data = data;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_data.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _data.GetById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            _data.Add(product);
            return Ok("Inserted Successfully");
        }

        [HttpPut]
        public IActionResult Put(Product product)
        {
            _data.Update(product);
            return Ok("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _data.Delete(id);
            return Ok("Deleted Successfully");
        }
    }
}
