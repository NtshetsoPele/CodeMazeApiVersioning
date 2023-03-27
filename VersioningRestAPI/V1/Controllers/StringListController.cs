using Microsoft.AspNetCore.Mvc;

namespace VersioningRestAPI.V1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // Default versioning scheme is Query String Parameter Versioning
    [ApiVersion("0.9", Deprecated = true)]
    [ApiVersion("1.0")]
    public class StringListController : ControllerBase
    {
        [HttpGet()]        
        public IEnumerable<string> Get()
        {
            return Data.Summaries.Where(s => s.StartsWith("B"));
        }
    }
}