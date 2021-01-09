using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void chatHandler(int type ,string str); 
public class ChatUI : MonoBehaviour
{
    public event chatHandler receiveEvent;

    public ChatType[] chat;

    private void Awake() {
        chat = this.GetComponentsInChildren<ChatType>();
        foreach(var item in chat) {
            receiveEvent += item.FilterChat;
        }
    }    
    public void ReceiveMsg(string str) {
        receiveEvent.Invoke(1, str);
    }

}
