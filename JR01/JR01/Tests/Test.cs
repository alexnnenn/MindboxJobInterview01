using JR01.Extensions;
using JR01.Logic;
using JR01.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace JR01.Tests
{
	[TestClass]
	public class Test
	{
		private CitiesList Cities { get; set; }

		[TestInitialize]
		public void Initialization()
		{
			Cities = new CitiesList(1000);
		}

		[TestMethod]
		public void TestGeneration()
		{
			Assert.AreEqual(Cities.List.Count, Cities.List.Distinct().Count());
		}

		[TestMethod]
		public void TestSorting()
		{
			var sortedCards = Cities.List.Skip(1).Select((l, i) => new WayCard(Cities.List[i], l)).ToArray();
			var unsortedCards = sortedCards.Shuffle();
			CardSorter.Process(unsortedCards);
			for (var i = 0; i < sortedCards.Length; i++)
				Assert.AreEqual(sortedCards[i], unsortedCards[i]);
		}
	}
}
