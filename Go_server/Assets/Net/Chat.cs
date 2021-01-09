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

    [SerializeField]
    private ChatUI chatUI;
    [SerializeField]
    private NetKernel kernel;

    private void Awake() {
        kernel = this.GetComponent<NetKernel>();
        kernel.msgEvent += RequestMsg;
    }

    IEnumerator Start() {
        netMessage = this.GetComponent<INET_SEND>();
        yield return new WaitForSeconds(3f);
        SendMsg("Hello");
    }


    void SendMsg(string msg) {
        netMessage.Send(NetSubscribe.id + ":msg:" + msg);
    }

    void RequestMsg(string str) {
        chatUI.ReceiveMsg(str);
    }

}
