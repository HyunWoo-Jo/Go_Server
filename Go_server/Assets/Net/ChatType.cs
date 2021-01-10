using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatType : MonoBehaviour
{
    [HideInInspector]
    public int chatType = 1;

    private Text _text;

    private List<string> strList = new List<string>();

    private void Awake() {
        _text = this.GetComponent<Text>();
    }

    public void FilterChat(int type, string str) {
        if (type.Equals(chatType)) {
            InputList(str);
            ShowTextList();
        }
    }

    private void InputList(string str) {
        strList.Add(str);
        if (strList.Count > 20) {
            strList.RemoveAt(0);
        }
    }
    private void ShowTextList() {
        string str = "";
        foreach (var item in strList) {
            str += str == ""? item : "\n" + item;
        }
        _text.text = str;
    }

}
