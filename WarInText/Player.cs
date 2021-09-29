using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarInText
{
    class Player
    {
        public string Name { get; set; }
        public int NumberOfCards { get; set; }
        public Queue<Card> HandOfCards  { get; set; } 

        public Player ()
        {
            HandOfCards = new Queue<Card>();
        }
         
        // Will intake and set a User name
        public void PlayerName()
        {
            Console.Write("Welcome to War, user! Please enter your name: ");
            Name = Console.ReadLine();
        }

        public void ComputerPlayer()
        {
            Name = "Computer";
        }

       
        
        
    }
}
