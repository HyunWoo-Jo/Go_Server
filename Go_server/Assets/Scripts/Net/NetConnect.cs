using UnityEngine;
using System.Net.Sockets;
using System;

namespace Go.Net {

    public class NetConnect : MonoBehaviour {
        [HideInInspector]
        public TcpClient tcpClient;
        [HideInInspector]
        public NetworkStream stream;


        [HideInInspector]
        private string ip = "183.96.117.136";
        [HideInInspector]
        private int port = 7000;

        protected void Awake() { 
            TryConnect();
        }

        private void TryConnect() {
            try {
                tcpClient = new TcpClient(ip, port);
                stream = tcpClient.GetStream();
                Debug.Log("Connect");
                Net.instance.isConnectServer = true;
            } catch (Exception e) {
                Debug.Log(e);
                Net.instance.isConnectServer = false;
            }
        }

    }
}
