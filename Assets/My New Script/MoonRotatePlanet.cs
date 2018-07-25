using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotatePlanet : MonoBehaviour {

    public GameObject sun;       //기준행성 (토성)
    public float speed;             //회전 속도
 
    private void Update()
    {
        OrbitAround();
    }
 
    void OrbitAround()
    {
        transform.RotateAround(sun.transform.position, Vector3.down, speed * Time.deltaTime);
    }
    // RotateAround(Vector3 point, Vector3 axis, float angle)
}

