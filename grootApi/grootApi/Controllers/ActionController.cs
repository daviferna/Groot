using GrootCore;
using GrootTypes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace grootApi.Controllers
{
    public class ActionController : ApiController
    {

        public IEnumerable<DtoAction> Get()
        {
            return GrootBusiness.getActions();
        }

        [HttpPost]
        public void Post(DtoPostAction data)
        {
            GrootBusiness.addAction(data.Position, data.Side);
        }
    }
}
