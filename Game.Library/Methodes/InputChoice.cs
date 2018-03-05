using System;

namespace Game.Library.Methodes
{
    public class InputChoice
    {
        public static int Choice(int max)
        {
            var tablecheck = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            Console.Write("\nVotre Choix : ");
            char input = new char();
            input = Console.ReadKey().KeyChar;
            bool ok = false;
            foreach (var c in tablecheck)
            {
                if (c == input)
                {
                    ok = true;
                    break;
                }
            }

            if (!ok)
            {
                return Choice(max);
            }

            int x = int.Parse(input.ToString());
            if (x < 1 | x > max)
            {
                return Choice(max);
            }

            return x;
        }
    }
}
