using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Go.Net;

namespace Go.UI {
    public class UI_Chat : UI_Popup {
        [SerializeField]
        private InputField sendInputField;
        [SerializeField]
        private Text _text;

        [SerializeField]
        private ChatSystem chat;
        public bool isSend = true;

       
        private void Update() {
            if (!isCreation) return;

            if (isSend) {
                if (Input.GetKeyDown(KeyCode.Y)) {
                    SendMsg();
                }
                if (Input.GetKeyDown(KeyCode.KeypadEnter)) {
                    SendMsg();
                }
            }
        }
        private void SendMsg() {
            chat.SendMsg(sendInputField.text);
            sendInputField.text = "";
        }

        public void ShowTextList(List<string> strList) {
            string str = "";     
            foreach (var item in strList) {
                str += str == "" ? item : "\n" + item;
            }
            _text.text = str;
        }

        public override void OnCreate(UI_Manager manager) {
            Object _object = Instantiate(Resources.Load("UI/UI_Chat"));
            GameObject obj = _object as GameObject;
            if (obj == null) {
                Debug.Log("err");
                return;
            }
            obj.GetComponent<UI_Popup>().isCreation = true;
            obj.transform.SetParent(manager.canvas.transform);
        }
    }
}