using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFllow : MonoBehaviour
{
    public Transform target;
    public float positionSpeed = 1;
    public float rotateSpeed = 1;

    public bool isPosition = true;
    public bool isRotate = true;

    public Vector3 position;

    protected void Update() {
        
        if(isPosition)
            this.transform.position = Vector3.Slerp(this.transform.position, target.transform.position + position,
                Time.deltaTime * positionSpeed);
        if (isRotate)
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
                Quaternion.LookRotation(target.position - this.transform.position),
                rotateSpeed * Time.deltaTime);       
    }
}
