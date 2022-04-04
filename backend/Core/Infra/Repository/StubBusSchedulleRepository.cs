using System;
using System.Globalization;
using Core.Contracts;
using Core.Domain;

namespace Core.Infra.Repository
{
	public class StubBusSchedulleRepository:IBusSchedulleRepository
	{

		public async Task<BusSchedulleResponse> FindbyRouteName(int RouteInterval, int BusInterval, string BusRouteName, string BusStopName)
		{
			int IntervalParameter = 15;

			List<DateTime> query = Enumerable
			  .Range(0, (int)(new TimeSpan(24, 0, 0).TotalMinutes / IntervalParameter))
			  .Select(i => DateTime.Today.AddMinutes((RouteInterval-1) + (BusInterval-1))
				 .AddMinutes(i * (double)IntervalParameter) 
			  ).ToList();
			var NextArrivals = query.Where(x => x >= DateTime.Now && x <= DateTime.Now.AddMinutes(45)).Select(x => ((int)Math.Ceiling(x.Subtract(DateTime.Now).TotalMinutes)).ToString()).ToList();
			//var NextArrivals = query.Where(x => x >= DateTime.Now && x <= DateTime.Now.AddMinutes(45)).Select(x => x.ToString("HH:mm tt", new CultureInfo("en-US"))).ToList();
			NextArrivals.RemoveAt(2);
			var BusSchedulle = new BusSchedulleResponse { Route = BusRouteName, BusTime = NextArrivals.ToArray(), BusStop = BusStopName };

			return await Task.FromResult(BusSchedulle);
		}

	}
}

