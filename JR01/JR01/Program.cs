using JR01.Logic;
using JR01.Models;

namespace JR01
{
	class Program
	{
		static void Main(string[] args)
		{
			var citiesList = new CitiesList(100000);
			var generator = new WayCardGenerator(citiesList);
			var cardsToSort = generator.GenerateWayCards();

			CardSorter.Process(cardsToSort);
		}
	}
}
