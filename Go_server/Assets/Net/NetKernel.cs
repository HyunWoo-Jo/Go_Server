using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void NetMsg(string str);
public class NetKernel : MonoBehaviour
{
    NetConnect nconn;

    public event NetMsg msgEvent;
    
    private void Awake() {
        nconn = this.GetComponent<NetConnect>();
    }

    public void Recive(string str) {
        msgEvent.Invoke(str);
    }

}
