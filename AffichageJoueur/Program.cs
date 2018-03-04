using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;

namespace AffichageJoueur
{
    class Program
    {

        static void Main(string[] args)
        {
            var server = new ServerAffichage();
            server.Run();
            server.ReadMessages();
        }
    }

}
