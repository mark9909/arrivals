using System;
using Core.Contracts;

namespace Core.Domain
{
	public interface IBusSchedulleRepository
	{
		Task<BusSchedulleResponse> FindbyRouteName(int RouteInterval, int BusInterval, string BusRouteName, string BusStopName);
	}
}

