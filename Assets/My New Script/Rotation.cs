using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

	public float downSpeed = 0f;         //회전속도
    public float forwardSpeed = 0f;         //회전속도
    public float rightSpeed = 0f;
    private void Update()
    {
        Orbit_Rotation();
    }
 
    void Orbit_Rotation()
    {   
        transform.Rotate(Vector3.right * rightSpeed * Time.deltaTime);
        transform.Rotate(Vector3.down * downSpeed * Time.deltaTime);
        transform.Rotate(Vector3.forward * forwardSpeed * Time.deltaTime);
        //transform.Rotate(Vector3 EularAngle)
    }

	
}
