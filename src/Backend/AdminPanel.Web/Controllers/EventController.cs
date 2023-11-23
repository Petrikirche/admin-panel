using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AdminPanel.Data;
using AdminPanel.Data.Dto;
using AdminPanel.Data.Dto.DtoExtension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Web.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {   

        private readonly TicketsPetrekircheContext _context;

        public EventController(TicketsPetrekircheContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IEnumerable<EventDto> Get()
        {
            return _context.Events.Select(x => x.ToDto()).ToList();
        }

    }
}
