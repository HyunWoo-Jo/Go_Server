using System.Collections;
using System.Collections.Generic;
using UnityEngine;

delegate string NetEvent(string str);
public class NetKernel : MonoBehaviour
{
    NetConnect nconn;

    event NetEvent msgEventHandler;
    
    private void Awake() {
        nconn = this.GetComponent<NetConnect>();
    }

}
