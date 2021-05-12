using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    class ServerSend
    {
        private static void SendTCPData(int _toClient, Packet _packet)
        {
            _packet.WriteLength();
            Server.clients[_toClient].tcp.SendData(_packet);
        }

        private static void SendUDPData(int _toClient, Packet _packet)
        {
            _packet.WriteLength();
            Server.clients[_toClient].udp.SendData(_packet);
        }

        private static void SendTCPDataToAll(Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 0; i <= Server.MaxPlayers; i++)
            {
                Server.clients[i].tcp.SendData(_packet); 
            }
        }

        private static void SendTCPDataToAll(int _exceptClient, Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 0; i <= Server.MaxPlayers; i++)
            {
                if(i !=_exceptClient)
                {
                    Server.clients[i].tcp.SendData(_packet);
                }
            }
        }

        private static void SendUDPDataToAll(Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                Server.clients[i].udp.SendData(_packet);
            }
        }

        private static void SendUDPDataToAll(int _exceptClient, Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 0; i <= Server.MaxPlayers; i++)
            {
                if(i !=_exceptClient)
                {
                    Server.clients[i].udp.SendData(_packet);
                }
            }
        }


        #region Packets
        public static void Welcome(int _toClient, string _msg)
        {
            using(Packet _packet = new Packet((int)ServerPackets.welcome))
            {
                _packet.Write(_msg);
                _packet.Write(_toClient);

                SendTCPData(_toClient, _packet); 
            }
            
        }

        public static void SpawnPlayer(int _toClient, Player _player)
        {
            using (Packet _packet = new Packet((int)ServerPackets.spawnPlayer))
            {
                _packet.Write(_player.id);
                _packet.Write(_player.username);
                _packet.Write(_player.position);

                _packet.Write(_player.rotation);

                SendTCPData(_toClient, _packet);
            }
        }

        public static void PlayerPosition(Player _player) 
        { 
            using (Packet _packet = new Packet((int)ServerPackets.playerPosition))
            {
                _packet.Write(_player.id);
                _packet.Write(_player.position);

                SendUDPDataToAll(_packet); 
            }
        }
        public static void PlayerRotation(Player _player) 
        { 
            using (Packet _packet = new Packet((int)ServerPackets.playerRotation))
            {
                _packet.Write(_player.id);
                _packet.Write(_player.rotation);

                SendUDPDataToAll(_packet); 
            }
        }

        //For Rythem vs
        //send score packet to client
        public static void PlayerScore(Player _player)
        {
            using (Packet _packet = new Packet((int)ServerPackets.playerScore))
            {
                _packet.Write(_player.id);
                _packet.Write(_player.score);

                SendUDPDataToAll(_packet);
            }
        }
        public static void PlayerCheck(Player _player)
        {
            using (Packet _packet = new Packet((int)ServerPackets.playerCheck))
            {
                _packet.Write(_player.id);
                _packet.Write(_player.check);

                SendUDPDataToAll(_packet);
            }
        }

        public static void PlayerInfo(int _toClient, Player _player)
        {
            using (Packet _packet = new Packet((int)ServerPackets.playerInfo))
            {
                _packet.Write(_player.id);
                _packet.Write(_player.username);

                SendTCPData(_toClient, _packet);
            }
        }

        public static void SpawnLobby(int _toClient, Player _player)
        {
            using (Packet _packet = new Packet((int)ServerPackets.spawnLobby))
            {
                SendTCPData(_toClient, _packet);
            }
        }

        public static void PlayerEnable(int _toClient, Player _player)
        {
            using (Packet _packet = new Packet((int)ServerPackets.playerEnable))
            {
                SendTCPData(_toClient, _packet);
            }
        }

        public static void PlayerHit(Player _player)
        {
            using (Packet _packet = new Packet((int)ServerPackets.playerHit))
            {
                _packet.Write(_player.id);

                SendUDPDataToAll(_packet);
            }
        }

        public static void PlayerMiss(Player _player)
        {
            using (Packet _packet = new Packet((int)ServerPackets.playerMiss))
            {
                _packet.Write(_player.id);

                SendUDPDataToAll(_packet);
            }
        }
        #endregion
    }
}
