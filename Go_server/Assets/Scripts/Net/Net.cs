using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Go.Net {
    public class Net : SingletonObject<Net> {

        public NetConnect connect;
        public NetKernel kernel;
        public NetMessage message;
        public bool isConnectServer = false;

        protected override void Awake() {
            base.Awake();
            connect = this.GetComponent<NetConnect>();
            kernel = this.GetComponent<NetKernel>();
            message = this.GetComponent<NetMessage>();
        }
    }
}