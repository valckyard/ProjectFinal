using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace AffichageJoueur
{
    public partial class Program
    {

        public static Thread Affichage;
        public static Thread ReadMess;

        static void Main(string[] args)
        {
            Start();
        }

        private static void Start()
        {
            PositionWindow();
            Console.SetWindowSize(27, 5);
            Console.CursorVisible = false;
            var server = new ServerAffichage();
            server.Run();
            Affichage = new Thread(server.AffichageStats);
            ReadMess = new Thread(server.ReadMessages);
            ReadMess.Start();
            Affichage.Start();
        }
    }
}
