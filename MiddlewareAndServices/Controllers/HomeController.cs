using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiddlewareAndServices.Services;

namespace MiddlewareAndServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly FileManagerAbstract _fleManager;
        public HomeController(IConfiguration config
            , ILogger<HomeController> logger,
            IWebHostEnvironment env
            , FileManagerAbstract fleManager)
        {
            _config = config;
            _logger = logger;
            _env = env;
            _fleManager = fleManager;
        }

        [HttpGet("ApplicationPath")]
        public IActionResult TryGetApplicationPath()
        {
            try
            {
                string conStrin = _config.GetConnectionString("DefultConnection");
                return Ok(_env.ContentRootPath);

            }
            catch (Exception ex)
            {

                _logger.LogError($"From ILogger. Something went wrong : {ex}");
            }
            return Ok();
        }
        [HttpPost("ToByteArray")]
        public async Task<IActionResult> ConvertImageToByteArray(IFormFile file)
        {

            return Ok(await _fleManager.UploadFileToByteArray(file));
        }
    }
}
