using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System;


public class Chat : MonoBehaviour
{
    NetConnect nc;

    void Start()
    {
        nc = this.GetComponent<NetConnect>();
        SendMsg("41234:msg:Hello");      
    }

    // Update is called once per frame
    void Update()
    {
        if (!nc.isConnectServer) return;
        RequestMsg();
    }

    void SendMsg(string msg) {
       
        byte[] buff = Encoding.ASCII.GetBytes(msg);
   
        nc.stream.Write(buff, 0, buff.Length);
        Debug.Log("Stream");
    }

    void RequestMsg() {
        try {
            if (!nc.stream.DataAvailable) return;
            byte[] buff = new byte[4096];
            int nbytes;
            if ((nbytes = nc.stream.Read(buff, 0, 4096)) > 0) {
                string msg = Encoding.ASCII.GetString(buff);
                Debug.Log(msg);
            }
        } catch(Exception e) {
            Debug.Log(e);
        }
        
    }

}
