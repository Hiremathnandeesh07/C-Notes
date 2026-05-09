


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_CORE_CRUD_Nandeesh_WithDataBase_ProdctsTable.Models;

namespace WEBAPI_CORE_CRUD_Nandeesh_WithDataBase_ProdctsTable.Controllers
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
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
