using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System;

public class NetConnect : MonoBehaviour
{
    [HideInInspector]
    public TcpClient tcpClient;
    [HideInInspector]
    public NetworkStream stream;
    [HideInInspector]
    public bool isConnectServer = false;

    [HideInInspector]
    public string ip = "220.116.106.202";
    [HideInInspector]
    public int port = 7000;

    private void Awake() {
        TryConnect();      
    }
    
    bool TryConnect() {
        try {
            tcpClient = new TcpClient(ip, port);
            stream = tcpClient.GetStream();
            Debug.Log("Connect");
            isConnectServer = true;
        } catch (Exception e) {
            Debug.Log(e);
            isConnectServer = false;
        }
        return isConnectServer;
    }
    
    
}
