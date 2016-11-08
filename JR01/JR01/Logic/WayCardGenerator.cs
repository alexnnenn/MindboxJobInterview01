using JR01.Extensions;
using JR01.Models;
using System.Linq;

namespace JR01.Logic
{
	internal class WayCardGenerator
	{
		public CitiesList Cities { get; private set; }

		public WayCardGenerator(CitiesList cities)
		{
			Cities = cities;
		}

		internal WayCard[] GenerateWayCards()
		{
			return Enumerable.Range(0, Cities.List.Count - 1)
				.Select(i => new WayCard(Cities.List[i], Cities.List[i + 1]))
				.Shuffle()
				.ToArray();
		}
	}
}
