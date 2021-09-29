using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarInText
{
    class Card
    {
        private static int NextId { get; set; } = 1;
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Value { get; set; }       
        
        public Card () { }
        public Card ( string name, int value)
        {
            this.Id = NextId++;
            this.Name = name;
            this.Value = value;
        }
        
    }
}
