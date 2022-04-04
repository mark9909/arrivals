using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Contracts;
using Core.Domain;
using Core.Infra.Repository;
using Core.Infra;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArrivalsProject.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [ActivatorUtilitiesConstructor]
    public class BusSchedulleController : ControllerBase
    {

        private IBusSchedulleRepository Repository { get; }
        private IBusRouteRepository RouteRepository { get; }
        private IBusStopRepository BusRepository { get; }


        private async Task<int> GetBusInterval(string BusStopName)
        {
            var objBusReturn = await BusRepository.FindAll();
                return objBusReturn.Where(x => x.Name == BusStopName).Select(y => y.BusDelay).FirstOrDefault();
        }

        private async Task<int> GetRouteInterval(string BusRouteName)
        {
            var objRouteReturn = await RouteRepository.FindAll();
            return objRouteReturn.Where(x => x.Name == BusRouteName).Select(y => y.BusDelay).FirstOrDefault();
        }

        [HttpGet]
        [EnableCors("Defaultc")]
        public async Task<List<BusSchedulleMessageResponse>> GetAll()
        {

            List<BusSchedulleMessageResponse> BusSchedulleList = new List<BusSchedulleMessageResponse>();
            string DisplayMessage = string.Empty;
            var Route1 = await GetStopRoutes("Stop 1", "Route 1");
            DisplayMessage = Route1.BusStop+" "+Route1.Route + ": in " + Route1.BusTime[0] +" minutes and " + Route1.BusTime[1] + " minutes and ";
            var Route2 = await GetStopRoutes("Stop 1", "Route 2");
            DisplayMessage += Route2.Route + ": in " + Route2.BusTime[0] + " minutes and " + Route2.BusTime[1] + " minutes and ";
            var Route3 = await GetStopRoutes("Stop 1", "Route 3");
            DisplayMessage += Route3.Route + ": in " + Route3.BusTime[0] + " minutes and " + Route3.BusTime[1] + " minutes";

            BusSchedulleList.Add(new BusSchedulleMessageResponse {BusStop= Route1.BusStop,BusMessage= DisplayMessage});
            DisplayMessage = String.Empty;
            var Stop2Route1 = await GetStopRoutes("Stop 2", "Route 1");
            DisplayMessage = Stop2Route1.BusStop + " " + Stop2Route1.Route + ": in " + Stop2Route1.BusTime[0] + " minutes and " + Stop2Route1.BusTime[1] + " minutes and ";
            var Stop2Route2 = await GetStopRoutes("Stop 2", "Route 2");
            DisplayMessage += Stop2Route2.Route + ": in " + Stop2Route2.BusTime[0] + " minutes and " + Stop2Route2.BusTime[1] + " minutes and ";
            var Stop2Route3 = await GetStopRoutes("Stop 2", "Route 3");
            DisplayMessage += Stop2Route3.Route + ": in " + Stop2Route3.BusTime[0] + " minutes and " + Stop2Route3.BusTime[1] + " minutes";

            BusSchedulleList.Add(new BusSchedulleMessageResponse { BusStop = Stop2Route1.BusStop, BusMessage = DisplayMessage });

            return BusSchedulleList;
        }

        private async Task<BusSchedulleResponse> GetStopRoutes(string BusStopName, string BusRouteName)
        {
            var RouteInterval = GetRouteInterval(BusRouteName).Result;
            var BusInterval = GetBusInterval(BusStopName).Result;
            if (RouteInterval > 0 && BusInterval > 0)
            {
                return await Repository.FindbyRouteName(RouteInterval, BusInterval, BusRouteName, BusStopName);
            }
            else
            {
                return new BusSchedulleResponse();
            }

        }



        public BusSchedulleController(IBusSchedulleRepository repository, IBusRouteRepository routeRepository, IBusStopRepository busRepository)
        {
            this.Repository = repository;
            this.RouteRepository = routeRepository;
            this.BusRepository = busRepository;
        }
    }
}

