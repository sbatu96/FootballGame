using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public int rotationSpeed = 50;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up,HorizontalInput*rotationSpeed*Time.deltaTime);
    }
}
