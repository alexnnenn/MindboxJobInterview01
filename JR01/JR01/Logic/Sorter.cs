using JR01.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JR01.Logic
{
	internal class CardSorter
	{
		internal static void Process(WayCard[] list)
		{
			var dicFrom = new Dictionary<string, WayCard>();
			var dicTo = new Dictionary<string, WayCard>();
			foreach (var card in list)
			{
				dicFrom.Add(card.Departure, card);
				dicTo.Add(card.Arrival, card);
			}
			
			//Примем первую карту за начальную, т.к.нам не важно, где она окажется в конце списка
			//Получаем два массива - от начальной карты и далее
			var middleCardAndAfter = InternalSort(dicFrom, list[0].Departure, e => e.Arrival).ToArray();
			//И до начальной карты
			var beforeMiddleCard = InternalSort(dicTo, list[0].Arrival, e => e.Departure).ToArray();
			//Массив до начальной карты идет в обратном порядке,т.к. проход вверх, поэтому необходимо его развернуть
			Array.Reverse(beforeMiddleCard);

			Array.Copy(beforeMiddleCard, list, beforeMiddleCard.Length);
			Array.Copy(middleCardAndAfter, 0, list, beforeMiddleCard.Length - 1, middleCardAndAfter.Length);
		}

		private static IEnumerable<WayCard> InternalSort(Dictionary<string, WayCard> dicFrom, string firstKey,  Func<WayCard, string> keyValuator)
		{
			var key = firstKey;
			while (true)
			{
				if (dicFrom.ContainsKey(key))
				{
					var card = dicFrom[key];
					yield return card;
					key = keyValuator(card);
					continue;
				}
				break;
			}
		}
	}
}
