using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Api.Models;

namespace Sample.Api.Controllers
{
    [Route("api/[controller]")]
    public class ConfigurationController : Controller
    {
        public ConfigurationController(ConfigurationResponse config)
        {
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(ConfigurationResponse), 200)]
        public async Task Get()
        {
            var configModel = new ConfigurationResponse();

            await Task.FromResult(configModel);
        }
    }
}
