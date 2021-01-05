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


    IEnumerator Start() {
        netMessage = this.GetComponent<INET_SEND>();
        yield return new WaitForSeconds(3f);
        SendMsg("Hello");
    }

    


    void SendMsg(string msg) {
        netMessage.Send(NetSubscribe.id + ":msg:" + msg);
    }

    void RequestMsg(string str) {
        Debug.Log(str);
    }

}
