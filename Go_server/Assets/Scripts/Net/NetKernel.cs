using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Go.Net {

    public delegate void NetMsg(string[] strs);
    public class NetKernel : MonoBehaviour {
        NetConnect nconn;

        public event NetMsg msgEvent;
        public event NetMsg positionEvent;
        public event NetMsg subEvent;
        public event NetMsg cancelEvent;

        private void Awake() {
            nconn = this.GetComponent<NetConnect>();
        }

        public void Recive(string str) {
            string[] mixed = str.Split(';');
            for (int i = 0; i < mixed.Length-1; i++) {
                string[] strs = mixed[i].Split(':');
                switch (strs[1]) {
                    case "msg":
                        msgEvent.Invoke(strs);
                        break;
                    case "position":
                        positionEvent.Invoke(strs);
                        break;
                    case "sub":
                        subEvent.Invoke(strs);
                        break;
                    case "cancel":
                        cancelEvent.Invoke(strs);
                        break;

                }
            }
        }

    }
}