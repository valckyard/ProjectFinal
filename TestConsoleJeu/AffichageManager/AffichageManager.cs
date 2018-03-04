using System;
using Game.Library.Classes.EntiteClasses;
using Lidgren.Network;

namespace TestConsoleJeu.AffichageManager
{
    public class AffichageManagerTest
    {
        public NetClient Client;

        public void Init()
        {
            NetPeerConfiguration config = new NetPeerConfiguration("FinalProjet");
            Client = new NetClient(config);
            Client.Start();
            var mOut = Client.CreateMessage();
            mOut.Write(JeuProjetTest.Player.MpMax);
            mOut.Write(JeuProjetTest.Player.MpActuel);
            mOut.Write(JeuProjetTest.Player.PvMax);
            mOut.Write(JeuProjetTest.Player.PvActuels);

          
            Client.Connect("localhost", 14242,mOut);
            Client.FlushSendQueue();
        }

        public void SendLoop()
        {
            NetIncomingMessage message;
            var stop = false;

            while (!stop)
            {
                


                while ((message = Client.ReadMessage()) != null)
                {
                    switch (message.MessageType)
                    {
                        case NetIncomingMessageType.Data:
                        {
                                message.ReadBoolean();
                                var mOut = Client.CreateMessage();
                                mOut.Write(JeuProjetTest.Player.MpMax);
                                mOut.Write(JeuProjetTest.Player.MpActuel);
                                mOut.Write(JeuProjetTest.Player.PvMax);
                                mOut.Write(JeuProjetTest.Player.PvActuels);
                                Client.SendMessage(mOut, Client.ServerConnection, NetDeliveryMethod.ReliableOrdered);
                                Client.FlushSendQueue();
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
