using System.Collections.Generic;
using System.Web.Http;

namespace OWIN.WebApi.Controllers
{
    [Authorize]
    public class ProtectedValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
