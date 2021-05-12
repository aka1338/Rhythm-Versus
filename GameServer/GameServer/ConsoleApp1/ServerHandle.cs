using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics; 

namespace GameServer
{
    class ServerHandle
    {
        public static void WelcomeRecieved(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();

            Console.WriteLine($"{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {_fromClient}.");

            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"Player \"{_username}\" (ID: {_fromClient}) has assumed the wrong client ID ({_clientIdCheck})!"); 
            }
            Server.clients[_fromClient].SendIntoGame(_username); 
            //Server.clients[_fromClient].ConnecttoGame(_username);
        }

        public static void PlayerMovement(int _fromClient, Packet _packet)
        {
            bool[] _inputs = new bool[_packet.ReadInt()];
            for (int i = 0; i < _inputs.Length; i++)
            {
                _inputs[i] = _packet.ReadBool(); 
            }
            Quaternion _rotation = _packet.ReadQuaternion();

            Server.clients[_fromClient].player.SetInput(_inputs, _rotation); 
        }

        //For Rythem vs
        //getting the score information from client
        public static void PlayerScore(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            int _score = _packet.ReadInt();

            Console.WriteLine($"(ID: {_fromClient}) get point");
            Server.clients[_fromClient].player.AddScore(_score);
        }
        public static void PlayerCheck(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            bool _check = _packet.ReadBool();

            if(_check == true)
            {
                Console.WriteLine($"(ID: {_fromClient}) is true");
            }
            else
            {
                Console.WriteLine($"(ID: {_fromClient}) is false");
            }
            
            Server.clients[_fromClient].player.Checking(_check);
        }

        public static void SpawnLobby(int _fromClient, Packet _packet)
        {
        }

        public static void PlayerEnable(int _fromClient, Packet _packet)
        {
            Console.WriteLine($"Control enable!!!!");
            Server.clients[_fromClient].PlayerEnable();
        }

    }
}
