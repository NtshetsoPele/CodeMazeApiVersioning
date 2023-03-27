using Microsoft.AspNetCore.Mvc;

namespace VersioningRestAPI.V3.Controllers
{
    // URI versioning is the most common versioning scheme because
    // the version information is easy to read right from the URI –
    // so it is an advantage.
    [ApiController]
    // Set a route substitution stating that the API version must
    // be in the URI with the v{version:apiVersion} format.
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("3.0")]
    public class StringListController : Controller
    {
        [HttpGet()]
        public IEnumerable<string> Get()
        {
            return Data.Summaries.Where((string s) => s.StartsWith("C"));
        }
    }
}
