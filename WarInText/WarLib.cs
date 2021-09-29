using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarInText
{
    class WarLib
    {
        // Initialize creating deck of cards and storing in queue
        public static Queue<Card> DeckAssembler()
        {
            Queue<Card> Deck = new Queue<Card>();
            var Club2 = new Card("2 of Clubs", 2);
            var Club3 = new Card("3 of Clubs", 3);
            var Club4 = new Card("4 of Clubs", 4);
            var Club5 = new Card("5 of Clubs", 5);
            var Club6 = new Card("6 of Clubs", 6);
            var Club7 = new Card("7 of Clubs", 7);
            var Club8 = new Card("8 of Clubs", 8);
            var Club9 = new Card("9 of Clubs", 9);
            var Club10 = new Card("10 of Clubs", 10);
            var ClubJack = new Card("Jack of Clubs", 11);
            var ClubQueen = new Card("Queen of Clubs", 12);
            var ClubKing = new Card("King of Clubs", 13);
            var ClubAce = new Card("Ace of Clubs", 14);
            var Diamond2 = new Card("2 of Diamonds", 2);
            var Diamond3 = new Card("3 of Diamonds", 3);
            var Diamond4 = new Card("4 of Diamonds", 4);
            var Diamond5 = new Card("5 of Diamonds", 5);
            var Diamond6 = new Card("6 of Diamonds", 6);
            var Diamond7 = new Card("7 of Diamonds", 7);
            var Diamond8 = new Card("8 of Diamonds", 8);
            var Diamond9 = new Card("9 of Diamonds", 9);
            var Diamond10 = new Card("10 of Diamonds", 10);
            var DiamondJack = new Card("Jack of Diamonds", 11);
            var DiamondQueen = new Card("Queen of Diamonds", 12);
            var DiamondKing = new Card("King of Diamonds", 13);
            var DiamondAce = new Card("Ace of Diamonds", 14);
            var Heart2 = new Card("2 of Hearts", 2);
            var Heart3 = new Card("3 of Hearts", 3);
            var Heart4 = new Card("4 of Hearts", 4);
            var Heart5 = new Card("5 of Hearts", 5);
            var Heart6 = new Card("6 of Hearts", 6);
            var Heart7 = new Card("7 of Hearts", 7);
            var Heart8 = new Card("8 of Hearts", 8);
            var Heart9 = new Card("9 of Hearts", 9);
            var Heart10 = new Card("10 of Hearts", 10);
            var HeartJack = new Card("Jack of Hearts", 11);
            var HeartQueen = new Card("Queen of Hearts", 12);
            var HeartKing = new Card("King of Hearts", 13);
            var HeartAce = new Card("Ace of Hearts", 14);
            var Spade2 = new Card("2 of Spades", 2);
            var Spade3 = new Card("3 of Spades", 3);
            var Spade4 = new Card("4 of Spades", 4);
            var Spade5 = new Card("5 of Spades", 5);
            var Spade6 = new Card("6 of Spades", 6);
            var Spade7 = new Card("7 of Spades", 7);
            var Spade8 = new Card("8 of Spades", 8);
            var Spade9 = new Card("9 of Spades", 9);
            var Spade10 = new Card("10 of Spades", 10);
            var SpadeJack = new Card("Jack of Spades", 11);
            var SpadeQueen = new Card("Queen of Spades", 12);
            var SpadeKing = new Card("King of Spades", 13);
            var SpadeAce = new Card("Ace of Spades", 14);

            Deck.Enqueue(Club2); Deck.Enqueue(Club3); Deck.Enqueue(Club4); Deck.Enqueue(Club5);
            Deck.Enqueue(Club6); Deck.Enqueue(Club7); Deck.Enqueue(Club8); Deck.Enqueue(Club9);
            Deck.Enqueue(Club10); Deck.Enqueue(ClubJack); Deck.Enqueue(ClubQueen);
            Deck.Enqueue(ClubKing); Deck.Enqueue(ClubAce); Deck.Enqueue(Diamond2);
            Deck.Enqueue(Diamond3); Deck.Enqueue(Diamond4); Deck.Enqueue(Diamond5);
            Deck.Enqueue(Diamond6); Deck.Enqueue(Diamond7); Deck.Enqueue(Diamond8);
            Deck.Enqueue(Diamond9); Deck.Enqueue(Diamond10); Deck.Enqueue(DiamondJack);
            Deck.Enqueue(DiamondQueen); Deck.Enqueue(DiamondKing); Deck.Enqueue(DiamondAce);
            Deck.Enqueue(Heart2); Deck.Enqueue(Heart3); Deck.Enqueue(Heart4); Deck.Enqueue(Heart5);
            Deck.Enqueue(Heart6); Deck.Enqueue(Heart7); Deck.Enqueue(Heart8); Deck.Enqueue(Heart9);
            Deck.Enqueue(Heart10); Deck.Enqueue(HeartJack); Deck.Enqueue(HeartQueen);
            Deck.Enqueue(HeartKing); Deck.Enqueue(HeartAce); Deck.Enqueue(Spade2);
            Deck.Enqueue(Spade3); Deck.Enqueue(Spade4); Deck.Enqueue(Spade5); Deck.Enqueue(Spade6);
            Deck.Enqueue(Spade7); Deck.Enqueue(Spade8); Deck.Enqueue(Spade9);
            Deck.Enqueue(Spade10); Deck.Enqueue(SpadeJack); Deck.Enqueue(SpadeQueen);
            Deck.Enqueue(SpadeKing); Deck.Enqueue(SpadeAce);

            return Deck;

        }

        // Shuffle method
        // Currently not always returning 52 cards
        // FIXED***
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
        //Three Shuffles
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
        // Method that plays a hand of cards
        public static void PlayHand(Player p1, Player p2)
        {
            bool isOver = IsOver(p1, p2);
            while (isOver == false)
            {

                Console.WriteLine($"{p1.Name} ---------------- {p2.Name}");
                Console.WriteLine($"{p1.HandOfCards.Peek().Name} " +
                    $"-------------{p2.HandOfCards.Peek().Name}");
                if (p1.HandOfCards.Peek().Value >
                    p2.HandOfCards.Peek().Value)
                {
                    p1.HandOfCards.Enqueue(p1.HandOfCards.Dequeue());
                    p2.HandOfCards.Enqueue(p2.HandOfCards.Dequeue());
                    p1.HandOfCards.Enqueue(p2.HandOfCards.Dequeue());
                    p1.NumberOfCards = p1.HandOfCards.Count; 
                    p2.NumberOfCards = p2.HandOfCards.Count;
                    Console.WriteLine($"{p1.Name} won this round.");
                   
                }
                else if (p1.HandOfCards.Peek().Value <
                    p2.HandOfCards.Peek().Value)
                {
                    p1.HandOfCards.Enqueue(p1.HandOfCards.Dequeue());
                    p2.HandOfCards.Enqueue(p2.HandOfCards.Dequeue());
                    p2.HandOfCards.Enqueue(p1.HandOfCards.Dequeue());
                    p1.NumberOfCards = p1.HandOfCards.Count;
                    p2.NumberOfCards = p2.HandOfCards.Count;
                    Console.WriteLine($"{p2.Name} won this round.");
                }
                else
                    War(p1, p2);
                isOver = IsOver(p1, p2);
                
            }
        }
        public static void War(Player p1, Player p2)
        {
            Console.WriteLine("WAR!!!");
            Console.WriteLine("1");
            Console.WriteLine("2");
            Console.WriteLine("3");
            Queue<Card> war1 = new Queue<Card>(); Queue<Card> war2 = new Queue<Card>();
            var CardsRemaining = 4;
            // Check to see if either player does not have enough cards to do war.
            if (p1.HandOfCards.Count < 4 || p2.HandOfCards.Count < 4)
            {
                CardsRemaining = Math.Min(p1.HandOfCards.Count, p2.HandOfCards.Count);
            }
            for (int i = 1; i <= CardsRemaining; i++)
            {
                war1.Enqueue(p1.HandOfCards.Dequeue());
                war2.Enqueue(p2.HandOfCards.Dequeue());

            }
            Console.WriteLine($"{war1.Last().Name} " +
                $"-------------{war2.Last().Name}");
            if (war1.Last().Value > war2.Last().Value)
            {
                while(war1.Count > 0)
                    p1.HandOfCards.Enqueue(war1.Dequeue());
                while(war2.Count > 0)
                    p1.HandOfCards.Enqueue(war2.Dequeue());
                p1.NumberOfCards = p1.HandOfCards.Count;
                p2.NumberOfCards = p2.HandOfCards.Count;

                Console.WriteLine($"{p1.Name} won the war!");
            }
            else if (war1.Last().Value < war2.Last().Value)
            {
                while(war1.Count > 0)
                    p2.HandOfCards.Enqueue(war1.Dequeue());
                while (war2.Count > 0)
                    p2.HandOfCards.Enqueue(war2.Dequeue());
                p1.NumberOfCards = p1.HandOfCards.Count;
                p2.NumberOfCards = p2.HandOfCards.Count;
                Console.WriteLine($"{p2.Name} won the war!");
            }
            else
                War(p1, p2);
        }




        // Method that checks whether the game is over or not
        static bool IsOver(Player p1, Player p2)
        {
            if (p1.NumberOfCards == 0 || p2.NumberOfCards == 0)
                return true;
            else
                return false;
        }
    }
}

