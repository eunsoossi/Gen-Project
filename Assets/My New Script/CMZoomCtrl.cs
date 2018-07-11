using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Serialization;


public class CMZoomCtrl : MonoBehaviour {


	private CinemachineFreeLook freelook;
	// public CinemachineFreeLook.Orbit[] originalOrbits = new CinemachineFreeLook.Orbit[0];
    
    // public float maxZomm = 10f;


    private float perspectiveZoomSpeed = 0.1f;        // The rate of change of the field of view in perspective mode.
    
    private float firstPOV;
    private float presentPOV;

    static float t = 0f;
    private bool resetPOV;



    // 마우스 끔 / 터치 켬
    public bool mouseOff;
    private GameObject[] cinemachineFreeLookZoom;

    


	void Awake() 
	{
		freelook = GetComponent<CinemachineFreeLook>();
        firstPOV = freelook.m_Lens.FieldOfView;
	}

    void Start()
    {
        // 마우스 끔 / 터치로 사용
        cinemachineFreeLookZoom = GameObject.FindGameObjectsWithTag("VirtualCam");
        if(mouseOff) 
        {
            for(int i = 0; i < cinemachineFreeLookZoom.Length; i++)
		    {
                cinemachineFreeLookZoom[i].GetComponent<CinemachineFreeLookZoom>().enabled = false;
            }
        }
    }


    public void POVreset() 
    {   
        resetPOV = true;
    }
  
    

    void Update()
    {   
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
        // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;


            // Otherwise change the field of view based on the change in distance between the touches.
            freelook.m_Lens.FieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

            // Clamp the field of view to make sure it's between 0 and 180.
            freelook.m_Lens.FieldOfView = Mathf.Clamp(freelook.m_Lens.FieldOfView, firstPOV - 30f, firstPOV);
            presentPOV = freelook.m_Lens.FieldOfView;
        }

        if (resetPOV)
        {   
            freelook.m_Lens.FieldOfView = Mathf.Lerp(presentPOV, firstPOV, t);
            presentPOV = freelook.m_Lens.FieldOfView;

            t += 0.3f * Time.deltaTime / 2f;
            
            if (presentPOV >= firstPOV - 1) 
            {   
                freelook.m_Lens.FieldOfView = firstPOV;
                t = 0f;
                resetPOV = false;
            }
        }   
    }
}

