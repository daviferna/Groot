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
    public class SnapshotController : ApiController
    {
        public IEnumerable<DtoSnapshot> Get()
        {
            return GrootBusiness.getSnapshots();
        }
    }
}
