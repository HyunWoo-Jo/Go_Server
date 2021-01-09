using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System;

public class NetConnect : MonoBehaviour
{
    public static bool IS_ConnectServer = false;
    [HideInInspector]
    public TcpClient tcpClient;
    [HideInInspector]
    public NetworkStream stream;


    [HideInInspector]
    private string ip = "220.116.108.187";
    [HideInInspector]
    private int port = 7000;

    private void Awake() {
        TryConnect();      
    }
    
    bool TryConnect() {
        try {
            tcpClient = new TcpClient(ip, port);
            stream = tcpClient.GetStream();
            Debug.Log("Connect");
            NetConnect.IS_ConnectServer = true;
        } catch (Exception e) {
            Debug.Log(e);
            NetConnect.IS_ConnectServer = false;
        }
        return NetConnect.IS_ConnectServer;
    }
    
    
}
