using ConfigurationProject.Model;
using ConfigurationProject.Services;
using ConfigurationProject.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;

namespace ConfigurationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurateController : ControllerBase
    {
        private readonly IConfigurateServices _configurateServices;
        private readonly IConfiguration _configuration;
        private readonly IOptions<ConfigService> _option;

        public ConfigurateController(IConfigurateServices configurateServices, IConfiguration configuration, IOptions<ConfigService> optionService)
        {
            _configurateServices = configurateServices;
            _configuration = configuration;
            _option = optionService;
        }

        [HttpGet("service-custom")]
        public IActionResult GetCustomConfigService()
        {
            return new JsonResult(_option.Value);
        }

        [HttpGet("di")]
        public IActionResult GetConfigService()
        {
            var returnMessage = _configuration.ToString().Log();

            return new ContentResult()
            {
                Content = returnMessage
            };
        }

        [HttpGet]
        public IActionResult GetConfig()
        {
            var configString = _configurateServices.GetConfiguration();
            "gohere".Log();
            return new ContentResult()
            {
                Content = configString
            };
        }
    }
}
