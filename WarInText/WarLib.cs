using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WarInText
{
    static class WarLib
    {
        // Initialize creating deck of cards and storing in queue
        public static Queue<Card> DeckAssembler()
        {
            Queue<Card> Deck = new Queue<Card>();
            Deck.Enqueue( new Card("2 of Clubs", 2));
            Deck.Enqueue(new Card("3 of Clubs", 3));
            Deck.Enqueue(new Card("4 of Clubs", 4));
            Deck.Enqueue( new Card("6 of Clubs", 6));
            Deck.Enqueue( new Card("7 of Clubs", 7));
            Deck.Enqueue( new Card("8 of Clubs", 8));
            Deck.Enqueue( new Card("9 of Clubs", 9));
            Deck.Enqueue( new Card("10 of Clubs", 10));
            Deck.Enqueue(new Card("5 of Clubs", 5));
            Deck.Enqueue( new Card("Jack of Clubs", 11));
            Deck.Enqueue( new Card("Queen of Clubs", 12));
            Deck.Enqueue( new Card("King of Clubs", 13));
            Deck.Enqueue(new Card("Ace of Clubs", 14));
            Deck.Enqueue( new Card("2 of Diamonds", 2));
            Deck.Enqueue( new Card("3 of Diamonds", 3));
            Deck.Enqueue( new Card("4 of Diamonds", 4));
            Deck.Enqueue( new Card("5 of Diamonds", 5));
            Deck.Enqueue( new Card("6 of Diamonds", 6));
            Deck.Enqueue( new Card("7 of Diamonds", 7));
            Deck.Enqueue( new Card("8 of Diamonds", 8));
            Deck.Enqueue(new Card("9 of Diamonds", 9));
            Deck.Enqueue(new Card("10 of Diamonds", 10));
            Deck.Enqueue(new Card("Jack of Diamonds", 11));
            Deck.Enqueue(new Card("Queen of Diamonds", 12));
            Deck.Enqueue(new Card("King of Diamonds", 13));
            Deck.Enqueue(new Card("Ace of Diamonds", 14));
            Deck.Enqueue(new Card("2 of Hearts", 2));
            Deck.Enqueue(new Card("3 of Hearts", 3));
            Deck.Enqueue(new Card("4 of Hearts", 4));
            Deck.Enqueue(new Card("5 of Hearts", 5));
            Deck.Enqueue(new Card("6 of Hearts", 6));
            Deck.Enqueue(new Card("7 of Hearts", 7));
            Deck.Enqueue(new Card("8 of Hearts", 8));
            Deck.Enqueue(new Card("9 of Hearts", 9));
            Deck.Enqueue( new Card("10 of Hearts", 10));
            Deck.Enqueue( new Card("Jack of Hearts", 11));
            Deck.Enqueue( new Card("Queen of Hearts", 12));
            Deck.Enqueue(new Card("King of Hearts", 13));
            Deck.Enqueue(new Card("Ace of Hearts", 14));
            Deck.Enqueue(new Card("2 of Spades", 2));
            Deck.Enqueue(new Card("3 of Spades", 3));
            Deck.Enqueue(new Card("4 of Spades", 4));
            Deck.Enqueue(new Card("5 of Spades", 5));
            Deck.Enqueue(new Card("6 of Spades", 6));
            Deck.Enqueue(new Card("7 of Spades", 7));
            Deck.Enqueue(new Card("8 of Spades", 8));
            Deck.Enqueue(new Card("9 of Spades", 9));
            Deck.Enqueue(new Card("10 of Spades", 10));
            Deck.Enqueue(new Card("Jack of Spades", 11));
            Deck.Enqueue( new Card("Queen of Spades", 12));
            Deck.Enqueue(new Card("King of Spades", 13));
            Deck.Enqueue(new Card("Ace of Spades", 14));
            return Deck;

        }

        // Shuffle method
        // FIXED***
        // Shuffles deck by pulling 1 - 3 cards from the beginning of the deck and then the end
        // of the deck repeatedly until a new deck is created.
        public static Queue<Card> ShuffleDeck(Queue<Card> initDeck)
        {
            Queue<Card> ShuffledDeck = new Queue<Card>();
            Random rand = new Random(); var CardCount = initDeck.Count();


            while (CardCount > 0)
            {
                int movedcards = rand.Next(1, 4);
                if (movedcards > CardCount)
                {
                    movedcards = CardCount;
                }
                for (int i = 1; i <= movedcards; i++)
                {

                    ShuffledDeck.Enqueue(initDeck.Dequeue());
                }

                initDeck = new Queue<Card>(initDeck.Reverse());
                CardCount = initDeck.Count;
            }

            return ShuffledDeck;
        }
        // Three Shuffles --> use this method in the program body.
        public static Queue<Card> MultiShuffler(Queue<Card> initDeck)
        {
            Queue<Card> FirstShuffle = new Queue<Card>();
            Queue<Card> SecondShuffle = new Queue<Card>();
            Queue<Card> ThirdShuffle = new Queue<Card>();

            foreach (Card card in initDeck)
                FirstShuffle.Enqueue(card);

            SecondShuffle = ShuffleDeck(FirstShuffle);
            return ThirdShuffle = ShuffleDeck(SecondShuffle);

        }
        // Method that deals out the shuffled cards to each player
        public static void Deal(Queue<Card> Deck, Player p1, Player p2)
        {

            var num = 1;
            foreach (Card card in Deck)
            {
                if (num % 2 != 0)
                {
                    p1.HandOfCards.Enqueue(card);
                    p1.NumberOfCards++;
                    num++;
                }
                else
                {
                    p2.HandOfCards.Enqueue(card);
                    p2.NumberOfCards++;
                    num++;
                }
            }

        }
        // Method to use the enter key to play a hand
        public static void KeyPress(Player p1, Player p2)
        {
            bool isOver = false;
            while (!isOver)
            {
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                {
                    isOver = PlayHand(p1, p2, isOver);
                }
                else
                {
                    Console.WriteLine(": Invalid Key Press. Try again");
                    continue;
                }

            }
        }
        // Method that plays a hand of cards
        public static bool PlayHand(Player p1, Player p2, bool isOver)
        {
             isOver = IsOver(p1, p2);
            

                Console.WriteLine($"{p1.Name} ---------------- {p2.Name}");
                Console.WriteLine($"{p1.HandOfCards.First().Name} " +
                    $"-------------{p2.HandOfCards.First().Name}");
                if (p1.HandOfCards.First().Value >
                    p2.HandOfCards.First().Value)
                {
                    p1.HandOfCards.Enqueue(p2.HandOfCards.Dequeue());
                    if (IsOver(p1, p2))
                    {
                        isOver = IsOver(p1, p2);
                    return isOver;
                    }
                    p1.HandOfCards.Enqueue(p1.HandOfCards.Dequeue());
                    p2.HandOfCards.Enqueue(p2.HandOfCards.Dequeue());
                    Console.WriteLine($"{p1.Name} won this round.");
                Console.WriteLine($"Current card count {p1.Name}: {p1.HandOfCards.Count}" +
                                $" {p2.Name}: {p2.HandOfCards.Count}");

                }
                else if (p1.HandOfCards.First().Value <
                    p2.HandOfCards.First().Value)
                {
                    p2.HandOfCards.Enqueue(p1.HandOfCards.Dequeue());
                    if (IsOver(p1, p2))
                    {
                        isOver = IsOver(p1, p2);
                        return isOver;
                    }
                    p1.HandOfCards.Enqueue(p1.HandOfCards.Dequeue());
                    p2.HandOfCards.Enqueue(p2.HandOfCards.Dequeue());
                    Console.WriteLine($"{p2.Name} won this round.");
                Console.WriteLine($"Current card count {p1.Name}: {p1.HandOfCards.Count}" +
                                $" {p2.Name}: {p2.HandOfCards.Count}");
            }
                else if (p1.HandOfCards.First().Value ==
                        p2.HandOfCards.First().Value)
                {
                    if (p1.HandOfCards.Count == 1 || p2.HandOfCards.Count == 1)
                    {

                        p1.HandOfCards.Dequeue();
                        p2.HandOfCards.Dequeue();
                        isOver = IsOver(p1, p2);
                        if (p1.HandOfCards.Count == 0)
                            Console.WriteLine($"{p1.Name} ran out of cards!");
                        else
                            Console.WriteLine($"{p2.Name} ran out of cards!");
                    return isOver;
                    }
                    War(p1, p2);
                }
                isOver = IsOver(p1, p2);
                return isOver;

            
        }

        public static void War(Player p1, Player p2)
        {
            Console.WriteLine("WAR!!!");
            for (var inc = 1; inc <= 3; inc++)
                Console.WriteLine(inc);
            Queue<Card> war1 = new Queue<Card>(); Queue<Card> war2 = new Queue<Card>();
            var CardsRemaining = 4;
            // Check to see if either player does not have enough cards to do war.
            if (p1.HandOfCards.Count < 4 || p2.HandOfCards.Count < 4 &&
                p1.HandOfCards.Count > 1 && p2.HandOfCards.Count > 1)
            {
                CardsRemaining = Math.Min(p1.HandOfCards.Count, p2.HandOfCards.Count);
            }
            // Bug fix for the case where the war card played by the player is their last card
            else if (p1.HandOfCards.Count == 0 || p2.HandOfCards.Count == 0)
            {

                return;
            }
            for (int i = 1; i <= CardsRemaining; i++)
            {
                war1.Enqueue(p1.HandOfCards.Dequeue());
                war2.Enqueue(p2.HandOfCards.Dequeue());

            }
            Console.WriteLine($"{war1.Last().Name} " +
                $"-------------{war2.Last().Name}");
            // Puts war winner cards into the correct deck
            if (war1.Last().Value > war2.Last().Value)
            {
                while (war1.Count > 0)
                    p1.HandOfCards.Enqueue(war1.Dequeue());
                while (war2.Count > 0)
                    p1.HandOfCards.Enqueue(war2.Dequeue());
 

                Console.WriteLine($"{p1.Name} won the war!");
                Console.WriteLine($"Current card count {p1.Name}: {p1.HandOfCards.Count}" +
                                $" {p2.Name}: {p2.HandOfCards.Count}");
            }
            else if (war1.Last().Value < war2.Last().Value)
            {
                while (war1.Count > 0)
                    p2.HandOfCards.Enqueue(war1.Dequeue());
                while (war2.Count > 0)
                    p2.HandOfCards.Enqueue(war2.Dequeue());
                Console.WriteLine($"{p2.Name} won the war!");
                Console.WriteLine($"Current card count {p1.Name}: {p1.HandOfCards.Count}" +
                                $" {p2.Name}: {p2.HandOfCards.Count}");
            }
            else
            {
                if (p1.HandOfCards.Count == 0 || p2.HandOfCards.Count == 0)
                    return;
                MultiWar(p1, p2, war1, war2);
            }
        }
        public static void MultiWar(Player p1, Player p2, Queue<Card> w1, Queue<Card> w2)
        {
            Console.WriteLine("WAR!!!");
            for (var inc = 1; inc <= 3; inc++)
                Console.WriteLine(inc);
           
            // Creates multi war decks
            Queue<Card> war1 = new Queue<Card>(); Queue<Card> war2 = new Queue<Card>();
            
            var CardsRemaining = 4;
            // Check to see if either player does not have enough cards to do war.
            if (p1.HandOfCards.Count < 4 || p2.HandOfCards.Count < 4 &&
                p1.HandOfCards.Count > 0 && p2.HandOfCards.Count > 0)
            {
                CardsRemaining = Math.Min(p1.HandOfCards.Count, p2.HandOfCards.Count);
            }
            // Bug fix for the case where the war card played by the player is their last card
            else if (p1.HandOfCards.Count == 0 || p2.HandOfCards.Count == 0)
            {
                return;
            }
            for (int i = 1; i <= CardsRemaining; i++)
            {
                
                war1.Enqueue(p1.HandOfCards.Dequeue());
                war2.Enqueue(p2.HandOfCards.Dequeue());

            }
            Console.WriteLine($"{war1.Last().Name} " +
                $"-------------{war2.Last().Name}");
            // Puts war winner cards into the correct deck
            if (war1.Last().Value > war2.Last().Value)
            {
                while (war1.Count > 0)
                    p1.HandOfCards.Enqueue(war1.Dequeue());
                while (war2.Count > 0)
                    p1.HandOfCards.Enqueue(war2.Dequeue());
                while(w1.Count > 0)
                    p1.HandOfCards.Enqueue(w1.Dequeue());
                while(w2.Count > 0)
                    p1.HandOfCards.Enqueue(w2.Dequeue());
                Console.WriteLine($"{p1.Name} won the war!");
                Console.WriteLine($"Current card count {p1.Name}: {p1.HandOfCards.Count}" +
                                $" {p2.Name}: {p2.HandOfCards.Count}");
            }
            else if (war1.Last().Value < war2.Last().Value)
            {
                while (war1.Count > 0)
                    p2.HandOfCards.Enqueue(war1.Dequeue());
                while (war2.Count > 0)
                    p2.HandOfCards.Enqueue(war2.Dequeue());
                while (w1.Count > 0)
                    p2.HandOfCards.Enqueue(w1.Dequeue());
                while (w2.Count > 0)
                    p2.HandOfCards.Enqueue(w2.Dequeue());
                Console.WriteLine($"{p2.Name} won the war!");
                Console.WriteLine($"Current card count {p1.Name}: {p1.HandOfCards.Count}" +
                                $" {p2.Name}: {p2.HandOfCards.Count}");
            }
            else
            {
                while (w1.Count > 0)
                    war1.Enqueue(w1.Dequeue());
                while (w2.Count > 0)
                    war2.Enqueue(w2.Dequeue());
                MultiWar(p1, p2, war1, war2);

            }
        }

        // Method that checks whether the game is over or not
        static bool IsOver(Player p1, Player p2)
        {
            if (p1.HandOfCards.Count == 0 || p2.HandOfCards.Count == 0)
                return true;
            else
                return false;
        }


    }
}

