using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LienChu_moment4
{
    
    // Create a class for PokerGame 
    internal class PokerGame
    {

        // Set type and variable for class
        private string suit;
        private string value;

        // Set constructor for adding class 
        public PokerGame(string suit, string value)
        {
            this.suit = suit;
            this.value = value;
        }

        // Override ToString method 
        public override string ToString()
        {
            return $" {suit} {value}";
        }
    }
}

