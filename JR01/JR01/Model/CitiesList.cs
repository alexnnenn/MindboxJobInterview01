using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace JR01.Models
{
	/// <summary>
	/// Хранилище списка городов
	/// </summary>
	internal class CitiesList
	{
		#region Fields

		internal ReadOnlyCollection<string> List { get; private set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Создаем предзаполненный список городов с уникальными названиями
		/// </summary>
		/// <param name="count">Размер списка</param>
		public CitiesList(int count)
		{
			if (count < 1) throw new ArgumentOutOfRangeException("count", "Количество городов не может быть меньше 1");

			List = new ReadOnlyCollection<string>(Enumerable.Range(0, count).Select(id => string.Format("Город {0}", id)).ToList());
		}

		#endregion
	}
}
