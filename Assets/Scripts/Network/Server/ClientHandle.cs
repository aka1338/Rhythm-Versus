using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class ClientHandle : MonoBehaviour
{
   public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.Log($"Message from server: {_msg}");
        Client.instance.myId = _myId;

        ClientSend.WelcomeReceived();

        Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);
    }

    public static void SpawnPlayer(Packet _packet)
    {
        int _id = _packet.ReadInt();
        string _username = _packet.ReadString();
        Debug.Log($"ID read: {_id}");
        Vector3 _position = _packet.ReadVector3();
        Quaternion _rotation = _packet.ReadQuaternion();

        //SpwanPlayer allow movement control and holdinfo just get a empty prefab
        GameManager.instance.SpawnPlayer(_id, _username, _position, _rotation);
        //GameManager.instance.HoldInfo(_id, _username);

    }

    public static void PlayerPosition(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Vector3 _position = _packet.ReadVector3();

        //GameManager.players[_id].transform.position = _position; 
    }
        public static void PlayerRotation(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Quaternion _rotation = _packet.ReadQuaternion();

        //GameManager.players[_id].transform.rotation = _rotation; 
    }

    //project
    //Read score from the package from server
    public static void PlayerScore(Packet _packet)
    {
        int _id = _packet.ReadInt();
        int _score = _packet.ReadInt();
        //PlayerManager.AddScore();
        
        GameManager.players[_id].score = _score;
    }

    public static void PlayerCheck(Packet _packet)
    {
        int _id = _packet.ReadInt();
        bool _check = _packet.ReadBool();

        GameManager.players[_id].check = _check;
    }
    
    public static void PlayerInfo(Packet _packet)
    {
        int _id = _packet.ReadInt();
        string _username = _packet.ReadString();

        //GameManager.instance.HoldInfo(_id, _username);
    }

    //May delete later
    public static void SpawnLobby(Packet _packet)
    {
        //PlayerManager.SpwanIntoGame();
    }


    //when the serevr send singal to start game, this function should also make the game start to play
    public static void PlayerEnable(Packet _packet)
    {
        //Debug.Log($"Moving!!!!!!!!!!");
        ViewManager.Show<MinigameSelectView>();
        //ViewManager.Show<MinigameView>();
        GameManager.EnableControl();
    }

    //TODO finish coding to server ad clientsend
    public static void PlayerHit(Packet _packet)
    {
        int _id = _packet.ReadInt();
        //TODO: call the metod to add code
    }

    public static void PlayerMiss(Packet _packet)
    {
        int _id = _packet.ReadInt();
        //TODO: call the metod to add code
    }

}
