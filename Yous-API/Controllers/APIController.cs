using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using Yous;
using Yous_Api.Models;

namespace Yous_API.Controllers
{
    public class APIController : ApiController
    {
        [Route("api/GetServiceApiResult")]
        [HttpPost]
        public ObjResult GetServiceApiResult(dynamic obj)
        {
            IDictionary<string, object> route = new Dictionary<string, object>();
            UrlHelper helper = new UrlHelper(Request);
            route["controller"] = "Figure";
            route["action"] = "GetAll";
            string AbsoluteUrl = helper.Link("DefaultApi", route);
            return  RedirectToRoute("api/10000001", obj);
            return CreatedAtRoute("Post", new { }, obj);
 
        }

        [Route("api/10000001")]
        [HttpPost]
        public ObjResult GetUser(dynamic obj)
        {
            ObjResult result = new ObjResult();
            result.success = true;
            result.message = "ok";
            MySqlDbHelperDB dbhelper = new MySqlDbHelperDB();
            result.data = dbhelper.Fetch<base_area>("select * from base_area");
            return result;
        }

    }
}
