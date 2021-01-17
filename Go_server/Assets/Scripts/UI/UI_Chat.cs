using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


namespace Go.UI {
    public class UI_Chat : UI_Popup {
        [SerializeField]
        private InputField sendInputField;
        [SerializeField]
        private Text[] inputFieldText;

        public Dropdown dropdown;

        [SerializeField]
        private Text _text;

        public Action<string> sendHandler;
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
            sendHandler.Invoke(sendInputField.text);
            sendInputField.text = "";
        }

        public void ShowTextList(List<string> strList,Color color) {
            string str = "";     
            foreach (var item in strList) {
                str += string.Format("<color=#{0}>",ColorUtility.ToHtmlStringRGB(color));
                str += str == "" ? item : "\n" + item;
                str += "</color>";
            }
            _text.text = str;
        }

        public void ChangeSendTextColor(Color color) {
            foreach(var item in inputFieldText) {
                item.color = color;
            }
        }

        public override void OnCreate(UI_Manager manager) {
            UnityEngine.Object _object = Instantiate(Resources.Load("UI/UI_Chat"));
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