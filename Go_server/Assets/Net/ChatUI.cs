using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void chatHandler(int type ,string str); 
public class ChatUI : MonoBehaviour
{
    [SerializeField]
    private InputField sendInputField;

    public event chatHandler receiveEvent;
    public event chatHandler sendEvent;

    public ChatType[] chat;

    public bool isSend = true;

    private void Awake() {
        chat = this.GetComponentsInChildren<ChatType>();
        foreach(var item in chat) {
            receiveEvent += item.FilterChat;
        }
    }

    private void Update() {
        if (isSend) {
            if (Input.GetKeyDown(KeyCode.Y)) {
                SendMsg();
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter)) {
                SendMsg();
            }
        }
    }

    public void ReceiveMsg(int type, string str) {
        receiveEvent.Invoke(type, str);
    }
    private void SendMsg() {
        sendEvent.Invoke(1, sendInputField.text);
        sendInputField.text = "";
    }

}
