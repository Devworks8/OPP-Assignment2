using System;

namespace Assignment2.CardPicker
{
	class Card
	{
		enum Suit
        {
			Hearts = 1,
			Diamonds = 2,
			Clubs = 3,
			Spades = 4
        }

		enum CardValue
        {
			Two = 2,
			Three = 3,
			Four = 4,
			Five = 5,
			Six = 6,
			Seven = 7,
			Eight = 8,
			Nine = 9,
			Ten = 10,
			Jack = 11,
			Queen = 12,
			King = 13,
			Ace = 14
		}

		static Random random = new Random(1);
		/// <summary>
		/// Picks a random (with replacement) number of cards.
		/// </summary>
		/// <param name="numCards">The number of cards to choose at random.</param>
		/// <returns>An array of strings where each string represents a card.</returns>
		public static string[] PickSomeCards(int numCards)
		{
			string[] PickedCards = new string[numCards];

			for (int i = 0; i < numCards; i++)
			{
				CardValue value = RandomValue();

				if ((int)value < 11)
				{
					PickedCards[i] = string.Format("{0} of {1}", (int)value, RandomSuit());
				}
				else
				{
					PickedCards[i] = string.Format("{0} of {1}", value, RandomSuit());
				}
			}

			return PickedCards;
		}
		private static CardValue RandomValue()
		{
			return (CardValue)Enum.GetValues(typeof(CardValue)).GetValue(random.Next(2, 14));
		 }
		private static Suit RandomSuit()
		{
			return (Suit)Enum.GetValues(typeof(Suit)).GetValue(random.Next(1, 4));
		}
	}
}
