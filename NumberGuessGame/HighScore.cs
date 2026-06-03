using System;
using System.Collections.Generic;
using System.Text;

namespace NumberGuessGame
{
   public class HighScore
    {
        public string? Difficuly { get; set; }
        public int Attempts { get; set; }
        public double TimeSeconds { get; set; }
        public DateTime Date { get; set; }

    }
}
