using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void NetMsg(string []strs);
public class NetKernel : MonoBehaviour
{
    NetConnect nconn;

    public event NetMsg msgEvent;
    
    private void Awake() {
        nconn = this.GetComponent<NetConnect>();
    }

    public void Recive(string str) {
        string[] strs = str.Split(':');
        switch (strs[1]) {
            case "msg":
                msgEvent.Invoke(strs);
                break;
        }
    }

}
