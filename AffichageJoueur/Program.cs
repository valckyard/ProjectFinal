using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lidgren.Network;
using static AffichageJoueur.ServerAffichage;

namespace AffichageJoueur
{
    class Program
    {
        private static Thread _affichage;
        private static Thread _ReadMess;

        static void Main(string[] args)
        {
            var server = new ServerAffichage();
            server.Run();
            _affichage = new Thread(server.AffichageStats);
            _ReadMess = new Thread(server.ReadMessages);
            _ReadMess.Start();
            _affichage.Start();
        }
    }

}
