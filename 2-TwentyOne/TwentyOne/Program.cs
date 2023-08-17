using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.Initialize();
            deck.Shuffle();

            Player player = new Player();
            Dealer dealer = new Dealer();

            player.DrawCard(deck);
            dealer.DrawCard(deck);
            player.DrawCard(deck);
            dealer.DrawCard(deck, isHidden: true);

            Console.WriteLine("Welcome to Twenty-One!");
            Console.WriteLine("Player's Hand: ");
            player.DisplayHand();
            Console.WriteLine("Dealer's Hand: ");
            dealer.DisplayHand();

            bool playerBust = false;
            bool dealerBust = false;

            while (true)
            {
                Console.Write("Do you want to 'hit' or 'stand'? ");
                string choice = Console.ReadLine().ToLower();

                if (choice == "hit")
                {
                    player.DrawCard(deck);
                    player.DisplayHand();
                    if (player.GetHandValue() > 21)
                    {
                        playerBust = true;
                        break;
                    }
                }
                else if (choice == "stand")
                {
                    dealer.RevealHiddenCard();
                    dealer.DisplayHand();
                    while (dealer.GetHandValue() < 17)
                    {
                        dealer.DrawCard(deck);
                        dealer.DisplayHand();
                        if (dealer.GetHandValue() > 21)
                        {
                            dealerBust = true;
                            break;
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'hit' or 'stand'.");
                }
            }

            Console.WriteLine("Player's Hand: ");
            player.DisplayHand();
            Console.WriteLine("Dealer's Hand: ");
            dealer.DisplayHand();

            int playerValue = player.GetHandValue();
            int dealerValue = dealer.GetHandValue();

            if ((playerValue > dealerValue && !playerBust) || dealerBust)
            {
                Console.WriteLine("Player wins!");
            }
            else if ((dealerValue > playerValue && !dealerBust) || playerBust)
            {
                Console.WriteLine("Dealer wins!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }
        }
    }

    class Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }
        public int Value { get; set; }
    }

    class Deck
    {
        private List<Card> cards = new List<Card>();

        public void Initialize()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    int value = 0;
                    if (int.TryParse(rank, out int num))
                    {
                        value = num;
                    }
                    else if (rank == "A")
                    {
                        value = 11;
                    }
                    else
                    {
                        value = 10;
                    }

                    cards.Add(new Card { Suit = suit, Rank = rank, Value = value });
                }
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }

        public Card DrawCard()
        {
            Card drawnCard = cards[0];
            cards.RemoveAt(0);
            return drawnCard;
        }
    }

    abstract class PlayerBase
    {
        protected List<Card> hand = new List<Card>();

        public void DrawCard(Deck deck, bool isHidden = false)
        {
            Card drawnCard = deck.DrawCard();
            hand.Add(drawnCard);

            if (!isHidden)
            {
                Console.WriteLine($"Drawn: {drawnCard.Rank} of {drawnCard.Suit}");
            }
            else
            {
                Console.WriteLine("Drawn: [Hidden Card]");
            }
        }

        public void DisplayHand()
        {
            foreach (Card card in hand)
            {
                Console.WriteLine($"{card.Rank} of {card.Suit}");
            }
            Console.WriteLine("Total Value: " + GetHandValue());
        }

        public int GetHandValue()
        {
            int totalValue = 0;
            int numAces = 0;

            foreach (Card card in hand)
            {
                totalValue += card.Value;
                if (card.Rank == "A")
                {
                    numAces++;
                }
            }

            while (numAces > 0 && totalValue > 21)
            {
                totalValue -= 10;
                numAces--;
            }

            return totalValue;
        }
    }

    class Player : PlayerBase
    {
    }

    class Dealer : PlayerBase
    {
        public void RevealHiddenCard()
        {
            if (hand.Count > 0)
            {
                Console.WriteLine("Revealed: " + hand[1].Rank + " of " + hand[1].Suit);
            }
        }
    }
}
