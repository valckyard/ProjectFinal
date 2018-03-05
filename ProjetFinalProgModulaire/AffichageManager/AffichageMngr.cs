using System;
using Lidgren.Network;

namespace ProjetFinalProgModulaire.AffichageManager
{
    public class AffichageMngr
    {
        public NetClient Client;

        public void Init()
        {
            NetPeerConfiguration config = new NetPeerConfiguration("FinalProjet");
            Client = new NetClient(config);
            Client.Start();
            var mOut = Client.CreateMessage();
            mOut.Write(JeuProjet.Player.MpMax);
            mOut.Write(JeuProjet.Player.MpActuel);
            mOut.Write(JeuProjet.Player.PvMax);
            mOut.Write(JeuProjet.Player.PvActuels);
            Client.Connect("localhost", 14242, mOut);
            Client.FlushSendQueue();
        }

        public void SendLoop()
        {
            while (true)
            {
                NetIncomingMessage message;
                while ((message = Client.ReadMessage()) != null)
                {
                    switch (message.MessageType)
                    {
                        case NetIncomingMessageType.Data:
                            {
                                message.ReadBoolean();
                                var mOut = Client.CreateMessage();
                                mOut.Write(JeuProjet.Player.MpMax);
                                mOut.Write(JeuProjet.Player.MpActuel);
                                mOut.Write(JeuProjet.Player.PvMax);
                                mOut.Write(JeuProjet.Player.PvActuels);
                                mOut.Write(JeuProjet.Player.Arme.NomObjet);
                                mOut.Write(JeuProjet.Player.Armure.NomObjet);
                                Client.SendMessage(mOut, Client.ServerConnection, NetDeliveryMethod.ReliableOrdered);
                                Client.FlushSendQueue();
                            }
                            break;

                        case NetIncomingMessageType.DebugMessage:
                            break;

                        case NetIncomingMessageType.StatusChanged:
                            Console.WriteLine(message.SenderConnection.Status);
                            if (message.SenderConnection.Status == NetConnectionStatus.Connected) { }
                            if (message.SenderConnection.Status == NetConnectionStatus.Disconnected) { }
                            break;

                        case NetIncomingMessageType.WarningMessage:
                            message.ReadString();
                            break;
                    }

                    Client.Recycle(message);
                }
            }
        }

    }
}
