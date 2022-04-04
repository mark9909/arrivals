using System;
using Core.Contracts;

namespace Core.Domain
{
	public interface IBusStopRepository
	{
		Task<IList<BusStop>> FindAll();
	}

}

