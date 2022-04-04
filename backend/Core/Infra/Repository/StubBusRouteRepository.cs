using Core.Contracts;
using Core.Domain;

namespace Core.Infra.Repository
{
	public class StubBusRouteRepository : IBusRouteRepository
	{
		public async Task<IList<BusRoute>> FindAll()
		{
			var routes = new List<BusRoute>
			{
				new BusRoute{Name = "Route 1", BusDelay=1},
				new BusRoute{Name = "Route 2", BusDelay = 3},
				new BusRoute{Name = "Route 3", BusDelay = 5}
			};

			return await Task.FromResult(routes);
		}
	}
}



