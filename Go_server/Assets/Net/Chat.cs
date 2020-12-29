using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class Chat : MonoBehaviour
{
    string ipAdress = "220.116.106.202";
    int port = 7000;
    TcpClient tcp;

    // Start is called before the first frame update
    void Start()
    {
        ConnectServer();
        SendMsg("Hello");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ConnectServer() {
        tcp = new TcpClient(ipAdress, port);
        Debug.Log("Connect");
    } 

    void SendMsg(string msg) {
        byte[] buff = Encoding.ASCII.GetBytes(msg);
        NetworkStream stream = tcp.GetStream();
        stream.Write(buff, 0, buff.Length);
        Debug.Log("Stream");

        stream.Close();
    }

}
