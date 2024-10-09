using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Donation3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "GET";
        }

        [HttpPost]
        public string Post()
        {
            return "POST";
        }


        [HttpPut]
        public string Put()
        {
            return "PUT";
        }


        [HttpDelete]
        public string Delete()
        {
            return "DELETE";
        }

    }
}
