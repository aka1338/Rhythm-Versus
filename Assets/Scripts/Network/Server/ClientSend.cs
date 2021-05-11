using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour
{
    private static void SendTCPData(Packet _packet) 
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    private static void SendUDPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.udp.SendData(_packet);  
    }

    #region Packets
    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(UIManager.instance.usernameField.text);

            SendTCPData(_packet);
        }
    }

    public static void PlayerMovement(bool[] _inputs)
    {
        using(Packet _packet = new Packet((int)ClientPackets.playerMovement))
        {
            _packet.Write(_inputs.Length);
            foreach(bool _input in _inputs)
            {
                _packet.Write(_input);
            }
            _packet.Write(GameManager.players[Client.instance.myId].transform.rotation);

            SendUDPData(_packet); 
        }
    }

    //project
    //Send packet to server to add score 
    public static void AddScore(int score)
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerScore))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(Client.instance.score);

            SendUDPData(_packet);
        }
    }

    public static void Check(bool check)
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerCheck))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(Client.instance.check);

            SendUDPData(_packet);
        }
    }

    public static void LobbySpawn()
    {
        using (Packet _packet = new Packet((int)ClientPackets.spawnLobby))
        {
            //_packet.Write(Client.instance.check);


            //TODO: Go to the server side and write the Lobby spwan packet

            SendUDPData(_packet);
        }
    }

    public static void PlayerEnable()
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerEnable))
        {
            SendTCPData(_packet);
        }
    }

    public static void PlayerHit()
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerHit))
        {
            _packet.Write(Client.instance.myId);

            SendTCPData(_packet);
        }
    }

    public static void Miss()
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerMiss))
        {
            _packet.Write(Client.instance.myId);

            SendTCPData(_packet);
        }
    }
    #endregion

}
