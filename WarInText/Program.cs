using System;
using System.Collections.Generic;

namespace WarInText
{
    class Program
    {
        static void Main()
        {
            Player Player1 = new Player();
            Player Player2 = new Player();
            Player1.PlayerName();
            Player2.ComputerPlayer();

            
            Queue<Card> Deck = new Queue<Card>();
            Deck = WarLib.DeckAssembler();
            Queue<Card> ShuffledDeck = new Queue<Card>();
            ShuffledDeck = WarLib.MultiShuffler(Deck);
            WarLib.Deal(ShuffledDeck, Player1, Player2);
            WarLib.PlayHand(Player1, Player2);

            if(Player1.NumberOfCards != 0)
                Console.WriteLine($"Congratulations, {Player1.Name}, you are the winner!");
            else
                Console.WriteLine($"Congratulations, {Player2.Name}, you are the winner!");

            PlayAgain();








        }
        static void PlayAgain()
        { 
            Console.Write("Play again? y/n");
            var Again = Console.ReadLine();
            if (Again == "y" || Again == "Y")
                Main();
            else if (Again == "n" || Again == "N")
                return;
            else
            {
                Console.Write("Please enter a valid character, y or n");
                PlayAgain();
            }
        }
    }
        
        
}
