using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Contracts;
using Core.Domain;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArrivalsProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusStopController : ControllerBase
    {
        private IBusStopRepository Repository { get; }

        [HttpGet]
        [EnableCors("Defaultc")]
        public async Task<IList<BusStop>> GetAll()
        {
            var stops = await Repository.FindAll();
            return stops;
        }

        public BusStopController(IBusStopRepository repository)
        {
            this.Repository = repository;

        }
    }
}

