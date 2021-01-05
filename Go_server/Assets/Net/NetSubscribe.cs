using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NetSubscribe : MonoBehaviour
{
    INET_SEND netMessage;
    public static string id = "";
    public static string username = "ÀÌ½Â±â";

    private void Awake() {
        id = UnityEngine.Random.Range(30, 500).ToString();
    }
    void Start() {
        netMessage = this.GetComponent<INET_SEND>();      
        Subscribe();
    }
    void Subscribe() {
        netMessage.Send(id + ":sub:" + username);
    }
}
