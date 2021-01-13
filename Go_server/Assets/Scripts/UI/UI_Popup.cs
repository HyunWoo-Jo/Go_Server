using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Go.UI {
    public abstract class UI_Popup : MonoBehaviour {
        public bool isCreation = false;
        public virtual void OnCreate(UI_Manager manager) { }
    }

}