using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketLog.Models;
using TicketLog.Data;

namespace TicketLog.Controllers
{
    [Produces("application/json")]
    [Route("api/TicketApi")]
    public class TicketApiController : Controller
    {
        public object Get()
        {
            var repo = new TicketLog(new APplica)
        }
    }
}