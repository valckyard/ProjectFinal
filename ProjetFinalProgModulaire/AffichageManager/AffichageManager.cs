using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;

namespace ProjetFinalProgModulaire.AffichageManager
{
    public class AffichageManager
    {
        public NetClient Client;

        public void Init()
        {
            NetPeerConfiguration config = new NetPeerConfiguration("FinalProjet");
            Client = new NetClient(config);
            Client.Start();
            Client.Connect("localhost", 14242);
        }

        public void SendLoop()
        {
            NetIncomingMessage message;
            var stop = false;

            while (!stop)
            {
                var mOut = Client.CreateMessage();
                mOut.ReadAllFields(JeuProjet.Player);
                Client.SendMessage(mOut, Client.ServerConnection, NetDeliveryMethod.ReliableOrdered);


                while ((message = Client.ReadMessage()) != null)
                {
                    switch (message.MessageType)
                    {
                        case NetIncomingMessageType.Data:
                            {
                                
                            }

                            break;
                        case NetIncomingMessageType.DebugMessage:
                            Console.WriteLine(message.ReadString());
                            break;
                        case NetIncomingMessageType.StatusChanged:
                            Console.WriteLine(message.SenderConnection.Status);
                            if (message.SenderConnection.Status == NetConnectionStatus.Connected)
                            {

                                Console.WriteLine("{0} has connected.",
                                    message.SenderConnection.Peer.Configuration.LocalAddress);
                            }

                            if (message.SenderConnection.Status == NetConnectionStatus.Disconnected)
                            {
                                Console.WriteLine("{0} has disconnected.",
                                    message.SenderConnection.Peer.Configuration.LocalAddress);
                            }

                            break;
                        case NetIncomingMessageType.WarningMessage:
                            Console.WriteLine("Warning Message type: " + message.ReadString());

                            break;
                        default:
                            Console.WriteLine($"Unhandled message type: {message.MessageType}");
                            break;
                    }

                    Client.Recycle(message);
                }
            }
        }

    }
}
