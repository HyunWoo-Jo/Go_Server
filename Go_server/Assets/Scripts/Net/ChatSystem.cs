using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Go.UI;

namespace Go.Net {
    public delegate void chatHandler(int type, string str);
    public class ChatSystem : MonoBehaviour {
        I_NET_SEND netMessage;

        private UI_Chat chatUI;
        private NetKernel kernel;

        public int maxMsgCount = 20;

        private List<List<string>> strLists = new List<List<string>>();
        [SerializeField]
        private List<Color> strColorList = new List<Color>();
        public int currentChatType = 0;
        public int sendChatType = 0;

        protected void Awake() {

            chatUI = this.GetComponent<UI_Chat>();
            chatUI.sendHandler += SendMsg;

            netMessage = Net.instance.GetComponent<I_NET_SEND>();
            // kernel�� ���źθ� ����
            kernel = Net.instance.kernel;
            kernel.msgEvent += RequestMsg;
            

        }
        // �޽����� NetMessage�� ���� direct�� ����
        public void SendMsg(string msg) {        
            netMessage.Send(string.Format("{0}:msg:{1}:{2}:1", NetSubscribe.id, sendChatType.ToString(), msg));
        }
        // �޽����� ������ ���͸� ����
        void RequestMsg(string[] strs) {
            // strs[2] == type / strs[0] == id / strs[3] == msg
            FilterChat(Convert.ToInt32(strs[2]), strs[0] + ": " + strs[3]);
            chatUI.ShowTextList(strLists[currentChatType],strColorList[currentChatType]);
        }

        // type ���� List�� Msg�� ������
        public void FilterChat(int type, string str) {
            if (strLists.Count <= type) {
                strLists.Add(new List<string>());   
            }
            InputList(type, str);        
        }

        //�ִ� ���� ������ ������ ����
        private void InputList(int type, string str) {
            strLists[type].Add(str);
            if (strLists[type].Count > maxMsgCount) {
                strLists[type].RemoveAt(0);
            }
        }

        public void ChangeChatType(int type) {
            currentChatType = type;
        }

        public void ChangeSendChatType() {
            int type = chatUI.dropdown.value;
            sendChatType = type;
            chatUI.ChangeSendTextColor(GetStrColor(type));
            ChangeChatType(type);
        }
        public Color GetStrColor(int type) {
            return strColorList[type];
        }
    }
}