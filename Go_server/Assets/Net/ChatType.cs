using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatType : MonoBehaviour
{
    [HideInInspector]
    public int chatType = 1;

    private Text _text;

    private void Awake() {
        _text = this.GetComponent<Text>();
    }

    public void FilterChat(int type, string str) {
        if (type.Equals(chatType)) {
            _text.text += str;
        }
    }

}
