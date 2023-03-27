using Microsoft.AspNetCore.Mvc;

namespace VersioningRestAPI.V2.Controllers
{
    // URIs stay clean because we only modify the Accept header values
    // The scheme preserves our URIs between versions
    // Send versioning information by providing X-Version in the request’s
    // header (as we’ve configured with the 'ApiVersionReader' class in
    // our configuration)

    // In addition to sending version information in headers,
    // we can do the same via media type header 
    // In our configuration, we use MediaTypeApiVersionReader("ver")
    // to state that 'ver' should be a version information holder
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("2.0")]
    public class StringListController : Controller
    {
        [HttpGet()]
        public IEnumerable<string> Get()
        {
            return Data.Summaries.Where(s => s.StartsWith("S"));
        }
    }
}
