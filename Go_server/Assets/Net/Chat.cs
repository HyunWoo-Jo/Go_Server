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

    void Start() {
        netMessage = this.GetComponent<INET_SEND>();
        chatUI.sendEvent += SendMsg;
    }


    void SendMsg(int type, string msg) {
        netMessage.Send(string.Format("{0}:msg:{1}:{2}:1", NetSubscribe.id, type, msg));
    }

    void RequestMsg(string[] strs) {
        chatUI.ReceiveMsg(Convert.ToInt32(strs[2]), strs[0]+": "+strs[3]);
    }

}
