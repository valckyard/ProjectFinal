using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Game.Library.Classes.EntiteClasses;
using Lidgren.Network;

namespace AffichageJoueur
{
   public class ServerAffichage
    {
        private static NetServer _server;
        private static List<NetPeer> _client;
        private static Personnage _player;

        public void Run()
        {
            _player = new Personnage();
            _player.MpActuel = 1;
            _player.MpMax = 1;
            _player.PvActuels = 1;
            _player.PvMax = 1;
            _client = new List<NetPeer>();
            NetPeerConfiguration config = new NetPeerConfiguration("FinalProjet") {Port = 14242};
            config.DisableMessageType(NetIncomingMessageType.ConnectionApproval);
            _server = new NetServer(config);
            _server.Start();

            if (_server.Status == NetPeerStatus.Running)
            {
                Console.WriteLine("Server is running on port " + config.Port);
              
            }
            else
            {
                Console.WriteLine("Server not started...");
            }

        }

        public void ReadMessages()
        {
            NetIncomingMessage message;


            while (true)
            {
                while ((message = _server.ReadMessage()) != null)
                {

                    switch (message.MessageType)
                    {
                        case NetIncomingMessageType.Data:
                            _player.MpMax = message.ReadInt32();
                            _player.MpActuel = message.ReadInt32();
                            _player.PvMax = message.ReadInt32();
                            _player.PvActuels = message.ReadInt32();

                            var mout = _server.CreateMessage();
                            mout.Write(true);
                            _server.SendMessage(mout, message.SenderConnection, NetDeliveryMethod.ReliableOrdered);
                            _server.FlushSendQueue();


                            break;

                        case NetIncomingMessageType.DebugMessage:
                            Console.WriteLine(message.ReadString());
                            break;
                        case NetIncomingMessageType.StatusChanged:
                            _player.MpMax = message.ReadInt32();
                            _player.MpActuel = message.ReadInt32();
                            _player.PvMax = message.ReadInt32();
                            _player.PvActuels = message.ReadInt32();

                            mout = _server.CreateMessage();
                            mout.Write(true);
                            _server.SendMessage(mout, message.SenderConnection, NetDeliveryMethod.ReliableOrdered);
                            _server.FlushSendQueue();
                            Console.WriteLine(message.SenderConnection.Status);
                            if (message.SenderConnection.Status == NetConnectionStatus.Connected)
                            {
                                //message.SenderConnection.Approve();
                                _client.Add(message.SenderConnection.Peer);
                                Console.WriteLine("{0} has connected.",
                                    message.SenderConnection.Peer.Configuration.LocalAddress);
                            }

                            if (message.SenderConnection.Status == NetConnectionStatus.Disconnected)
                            {
                                _client.Remove(message.SenderConnection.Peer);
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

                    _server.Recycle(message);
                }
            }

        }

        public void AffichageStats()
        {
            var timetoget = DateTime.Now.AddMilliseconds(300);

            while (true)
            {
          
                    var timenow = DateTime.Now;
                    if (timenow >= timetoget)
                    {
                        Console.SetCursorPosition(0, 8);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("-----------------------\n||");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" HP:" + _player.PvActuels + "/" + _player.PvMax);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" MP :" + _player.MpActuel + "/" + _player.MpMax);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("||\n-----------------------");
                        Console.SetCursorPosition(0, 0);
                        timetoget = DateTime.Now.AddMilliseconds(300);
                    }

                }
            }
        }
    }
