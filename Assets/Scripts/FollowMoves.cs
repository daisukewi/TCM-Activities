using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoves : MonoBehaviour {

    public Transform followObject;
    private Vector3 moveTemp;
    public float offsetY = 2;
    public float offsetX = 2;

    // Use this for initialization
    void Start () {
        moveTemp = followObject.transform.position;
    }
    
    // Update is called once per frame
    void Update () {
        moveTemp = followObject.transform.position;
        moveTemp.y += offsetY;
        moveTemp.x += offsetX;
        moveTemp.z = transform.position.z;
        transform.position = moveTemp;
    }
}