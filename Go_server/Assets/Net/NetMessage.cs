using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System;

public class NetMessage : MonoBehaviour, INET_SEND
{
    NetConnect netConn;     // Net
    NetKernel netKernel;    // 커널

    void Awake() {
        netConn = this.GetComponent<NetConnect>();
        netKernel = this.GetComponent<NetKernel>();
    }

    // Update is called once per frame
    void Update() {
        if (!NetConnect.IS_ConnectServer) return;
        Requst();
    }

    public void Send(string msg) { // 메시지 서버에 전송
        Debug.Log("Send: " + msg);
        try {
            byte[] buff = Encoding.UTF8.GetBytes(msg);
            netConn.stream.Write(buff, 0, buff.Length);
        }
        catch(Exception e) {
            Debug.Log(e);
        }
    }

    void Requst() { // 메시지 받을경우
        try {
            if (!netConn.stream.DataAvailable) return;
            byte[] buff = new byte[4096];
            int nbytes;
            if ((nbytes = netConn.stream.Read(buff, 0, 4096)) > 0) {
                string msg = Encoding.UTF8.GetString(buff);
                Debug.Log("RE: " + msg);
            }
        } catch (Exception e) {
            Debug.Log(e);
        }

    }
}
