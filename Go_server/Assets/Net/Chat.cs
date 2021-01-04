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
    INET_SEND netMessage;
    string id = "¾È³ç";

    void Start()
    {
        netMessage = this.GetComponent<INET_SEND>();
        SendMsg("Hello");      
    }

    void SendMsg(string msg) {
        netMessage.Send(id + ":msg:" + msg);
    }

    void RequestMsg(string str) {
        Debug.Log(str);
    }

}
