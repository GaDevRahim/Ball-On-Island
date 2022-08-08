using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCamera : MonoBehaviour
{
    float horizontalInput;
    float speedRotation = 45.0f;

    void Update()
    {                                  
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * speedRotation * Time.deltaTime);
    }
}
