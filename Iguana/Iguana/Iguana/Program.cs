using System;

namespace Iguana
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (BattleScene game = new BattleScene())
            {
                game.Run();
            }
        }
    }
#endif
}

