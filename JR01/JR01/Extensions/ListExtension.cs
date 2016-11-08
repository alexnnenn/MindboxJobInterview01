using System;
using System.Collections.Generic;
using System.Linq;

namespace JR01.Extensions
{
	internal static class ListExtension
	{
		/// <summary>
		/// Случайное перемешивание списка
		/// </summary>
		internal static T[] Shuffle<T>(this IEnumerable<T> list)
		{
			Random rand = new Random();
			var listCopy = list.ToArray();

			for (int oldIndex = listCopy.Length - 1; oldIndex > 0; oldIndex--)
			{
				int newIndex = rand.Next(0, oldIndex + 1);
				T tmp = listCopy[oldIndex];
				listCopy[oldIndex] = listCopy[newIndex];
				listCopy[newIndex] = tmp;
			}

			return listCopy;
		}
	}
}
