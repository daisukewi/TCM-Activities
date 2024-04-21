using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float shipSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveDirection = Input.GetAxis("Horizontal");

        transform.Translate(moveDirection * shipSpeed * Time.deltaTime, 0.0f, 0.0f);
    }
}
