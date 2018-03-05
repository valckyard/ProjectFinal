using System;
using System.Collections.Generic;
using Game.Library.Classes.EntiteClasses;
using Game.Library.Classes.ObjClasses;
using Game.Library.Enums;
using Lidgren.Network;

namespace AffichageJoueur
{
   public class ServerAffichage
    {
        private static NetServer _server;
        public static List<NetPeer> ClientPeerList;
        private static Personnage _player;

        public void Run()
        {
            InitialStats();
            ClientPeerList = new List<NetPeer>();
            NetPeerConfiguration config = new NetPeerConfiguration("FinalProjet") {Port = 14242};
            config.DisableMessageType(NetIncomingMessageType.ConnectionApproval);
            _server = new NetServer(config);
            _server.Start();
        }

        public void ReadMessages()
        {
            while (true)
            {
                if (_player.PvActuels <= 0)
                {
                    Program.Affichage.Abort();
                    Program.ReadMess.Abort();
                    Console.WriteLine("DEAD!");
                    Console.WriteLine("Enter to Exit");
                    Environment.Exit(1);
                }

                NetIncomingMessage message;
                while ((message = _server.ReadMessage()) != null)
                {

                    switch (message.MessageType)
                    {
                        case NetIncomingMessageType.Data:
                            ReceiveStats(message);
                            break;

                        case NetIncomingMessageType.DebugMessage:
                      message.ReadString();
                            break;
                        case NetIncomingMessageType.StatusChanged:
                            InitialConnectInfo(message);

                            break;
                        case NetIncomingMessageType.WarningMessage:
                            message.ReadString();
                            break;
                    }

                    _server.Recycle(message);
                }
            }

        }

        private static void InitialConnectInfo(NetIncomingMessage message)
        {
            _player.MpMax = message.ReadInt32();
            _player.MpActuel = message.ReadInt32();
            _player.PvMax = message.ReadInt32();
            _player.PvActuels = message.ReadInt32();
            var mout = _server.CreateMessage();
            mout.Write(true);
            _server.SendMessage(mout, message.SenderConnection, NetDeliveryMethod.ReliableOrdered);
            _server.FlushSendQueue();

            if (message.SenderConnection.Status == NetConnectionStatus.Connected)
            {
                ClientPeerList.Add(message.SenderConnection.Peer);
            }

            if (message.SenderConnection.Status == NetConnectionStatus.Disconnected)
            {
                InitialStats();
                ClientPeerList.Remove(message.SenderConnection.Peer);
            }
        }

        private static void ReceiveStats(NetIncomingMessage message)
        {
            _player.MpMax = message.ReadInt32();
            _player.MpActuel = message.ReadInt32();
            _player.PvMax = message.ReadInt32();
            _player.PvActuels = message.ReadInt32();
            _player.Arme.NomObjet = message.ReadString();
            _player.Armure.NomObjet = message.ReadString();
            var mout = _server.CreateMessage();
            mout.Write(true);
            _server.SendMessage(mout, message.SenderConnection, NetDeliveryMethod.ReliableOrdered);
            _server.FlushSendQueue();
        }

        private static void InitialStats()
        {
            _player = new Personnage();
            _player.MpActuel = 100;
            _player.MpMax = 100;
            _player.PvActuels = 100;
            _player.PvMax = 100;
            _player.Arme = new ObjArme("Empty", TypeElement.Physique, 0);
            _player.Armure = new ObjArmure("Empty", TypeElement.Physique, 0);
        }

        public void AffichageStats()
        {
            var timetoget = DateTime.Now.AddMilliseconds(300);

            while (true)
            {
          
                    var timenow = DateTime.Now;
                    if (timenow >= timetoget)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.Write("---------------------------\n||");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" HP:" + _player.PvActuels + "/" + _player.PvMax);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" MP :" + _player.MpActuel + "/" + _player.MpMax);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("||\n---------------------------\n");
                        Console.Write($"Arme   : {_player.Arme.NomObjet}\nArmure : {_player.Armure.NomObjet}");
                        timetoget = DateTime.Now.AddMilliseconds(150);
                    }

                }
            }
        }
    }
