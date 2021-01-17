using UnityEngine;

namespace Go.Net {
    public class NetSubscribe : MonoBehaviour {
        I_NET_SEND netMessage;
        public static string id = "";
        public static string username = "ÀÌ½Â±â";

        private void Awake() {
            id = UnityEngine.Random.Range(30, 500).ToString();
        }
        void Start() {
            netMessage = this.GetComponent<I_NET_SEND>();
            Subscribe();
        }
        void Subscribe() {
            netMessage.Send(id + ":sub:" + username);

        }
    }

}