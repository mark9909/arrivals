using System;
namespace Core.Contracts
{
	public class BusSchedulleResponse
	{
		public string Route { get; set; }
		public string BusStop { get; set; }
		public string[] BusTime { get; set; }
	}
}
