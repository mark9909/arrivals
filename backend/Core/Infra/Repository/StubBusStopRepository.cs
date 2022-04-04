using Core.Contracts;
using Core.Domain;
using System;
namespace Core.Infra.Repository
{
	public class StubBusStopRepository : IBusStopRepository
	{
		public async Task<IList<BusStop>> FindAll()
		{
			var stops = new List<BusStop>
			{
				new BusStop{Name = "Stop 1",BusDelay=1},
				new BusStop{Name = "Stop 2",BusDelay=3},
				new BusStop{Name = "Stop 3",BusDelay=5},
				new BusStop{Name = "Stop 4",BusDelay=7},
				new BusStop{Name = "Stop 5",BusDelay=9},
				new BusStop{Name = "Stop 6",BusDelay=11},
				new BusStop{Name = "Stop 7",BusDelay=13},
				new BusStop{Name = "Stop 8",BusDelay=15},
				new BusStop{Name = "Stop 9",BusDelay=17},
				new BusStop{Name = "Stop 10",BusDelay=19}
			};

			return await Task.FromResult(stops);
		}
	}
}
