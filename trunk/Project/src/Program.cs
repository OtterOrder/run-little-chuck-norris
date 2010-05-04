using System;

namespace Coeur
{
    static class Program
    {
        static void Main(string[] args)
        {
            using (CoeurGame game = new CoeurGame())
            {
                game.Run();
            }
           
        }
    }
}

