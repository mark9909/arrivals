using System;
using Core.Contracts;

namespace Core.Domain
{
	public interface IBusRouteRepository
	{
		Task<IList<BusRoute>> FindAll();
	}

}

