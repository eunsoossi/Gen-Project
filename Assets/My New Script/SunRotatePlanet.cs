using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotatePlanet : MonoBehaviour {

	public GameObject moon;       //기준행성 (토성)
    public float speed;             //회전 속도
 
    private void Update()
    {
        OrbitAround();
    }
 
    void OrbitAround()
    {
        transform.RotateAround(moon.transform.position, Vector3.down, speed * Time.deltaTime);
    }
    // RotateAround(Vector3 point, Vector3 axis, float angle)
}
