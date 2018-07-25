using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackColor : MonoBehaviour 
{
	public Color colorWhite;
    public Color colorBlack;
    public float timeToFadeBackColor;
	public bool backColorOn = false;


    public Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        // cam.clearFlags = CameraClearFlags.SolidColor;
    }

    void Update()
    {
        BackColorChange();
    }

	public void BackColorChange()
	{
		if(backColorOn)
		{
			cam.backgroundColor = Color.Lerp(cam.backgroundColor, colorBlack, timeToFadeBackColor * Time.deltaTime);
		}
		else
		{
			cam.backgroundColor = Color.Lerp(cam.backgroundColor, colorWhite, timeToFadeBackColor * Time.deltaTime);
		}
	}
}
