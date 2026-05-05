using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyNewController : ControllerBase
    {
        [HttpGet]
        
        public string Get()
        {
            return "babu";
        }



    }
}
