using NumberGuessGame;
using System;
using System.Diagnostics;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {
        var game = new Game();
        do
        {
            game.Start();
        } while(game.AskPlayAgain());
    }
}