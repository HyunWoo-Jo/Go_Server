using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Go.Net;

public class Player : MonoBehaviour
{

    float speed = 20;
    
    public bool isPlayer = true;

    public string id = "";

    void Update()
    {
        if (!isPlayer) return;
        Vector3 positon = transform.position;
        InputArrowKey();
        if(positon != this.transform.position) {
            SendMyPosition();
        }
    }

    void SendMyPosition() {
        if (NetSubscribe.id == "") return;
        Vector3 position = this.transform.position;
        
        string str = string.Format("{0}:position:{1}:{2:0.###}:{3}:{4:0.###}:{5}:{6:0.###}:1;",
            NetSubscribe.id, 
            position.x < 0 ? true.ToString() : false.ToString(),Math.Abs(position.x).ToString(),
            position.y < 0 ? true.ToString() : false.ToString(), Math.Abs(position.y).ToString(),
            position.z < 0 ? true.ToString() : false.ToString(), Math.Abs(position.z).ToString());
        Net.instance.message.Send(str);
    }

    void InputArrowKey() {
        
        if (Input.GetKey(KeyCode.DownArrow)) {
            this.transform.position += speed * Vector3.back * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow)) {

            this.transform.position += speed * Vector3.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {

            this.transform.position += speed * Vector3.left * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {

            this.transform.position += speed * Vector3.right * Time.deltaTime;
        }
    }

    public void SetPosition(string[] strs) {
        float x = Convert.ToSingle(strs[3]) * (Convert.ToBoolean(strs[2]) ? -1 : 1);
        float y = Convert.ToSingle(strs[5]) * (Convert.ToBoolean(strs[4]) ? -1 : 1);
        float z = Convert.ToSingle(strs[7]) * (Convert.ToBoolean(strs[6]) ? -1 : 1);
        this.transform.position = new Vector3(x, y, z);
    }

}
