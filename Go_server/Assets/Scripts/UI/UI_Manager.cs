using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Go.UI {
    public class UI_Manager : MonoBehaviour {

        public GameObject canvas;
        
        private void Start() {
            CreateUI<UI_Chat>();
        }

        public void CreateUI<T>() where T : UI_Popup {
            GameObject obj = new GameObject();
            T t = obj.AddComponent<T>();
            t.OnCreate(this);
            Destroy(obj);
        }
    }
}