using grootApi.Dtos;
using GrootCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace grootApi.Controllers
{
    public class PlantController : ApiController
    {

        public IEnumerable<DtoPlant> Get()
        {
            return GrootBusiness.getPlantsInfo();
        }
    }
}
