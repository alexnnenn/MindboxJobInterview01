namespace JR01.Models
{
	/// <summary>
	/// Карточка путешествия
	/// </summary>
	internal class WayCard
	{
		internal string Departure { get; private set; }
		internal string Arrival { get; private set; }

		internal WayCard(string departure, string arrival)
		{
			Departure = departure;
			Arrival = arrival;
		}
	}
}
