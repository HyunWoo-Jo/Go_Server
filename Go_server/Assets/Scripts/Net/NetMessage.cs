using UnityEngine;
using System.Text;
using System;
using System.Net.Sockets;

namespace Go.Net {
    public class NetMessage : MonoBehaviour, I_NET_SEND {

        void Update() {
            if (!Net.instance.isConnectServer) return;
            Request();
        }

        public void Send(string msg) { // 메시지 서버에 전송
            try {
                byte[] buff = Encoding.UTF8.GetBytes(msg);
                Net.instance.connect.stream.Write(buff, 0, buff.Length);
                Debug.Log(msg);
            } catch (Exception e) {
                Debug.Log(e);
            }
        }

        void Request() { // 메시지 받을경우
            try {
                if (!Net.instance.connect.stream.DataAvailable) return;
                NetworkStream stream = Net.instance.connect.stream;

                byte[] buff = new byte[4096];
                int nbytes;
                if ((nbytes = Net.instance.connect.stream.Read(buff, 0, buff.Length)) > 0) {
                    Debug.Log(nbytes);
                    string msg = Encoding.UTF8.GetString(buff);
                    Net.instance.kernel.Recive(msg);
                    Debug.Log(msg);
                } 
            } catch (Exception e) {
                Debug.Log(e);
            }

        }
    }
}