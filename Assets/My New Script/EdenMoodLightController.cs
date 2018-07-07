using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdenMoodLightController : MonoBehaviour {

	public GameObject[] edenMoodLights;

	public Color edenMoodLightsColor1;
    public Color edenMoodLightsColor2;
	public float timeToFadeBackColor;


	void Start() 
	{
		edenMoodLights = GameObject.FindGameObjectsWithTag("EdenMoodLight");
	}

	public void MoodLightDark() 
	{
		for (int i = 0; i < edenMoodLights.Length; i++)
        {
            edenMoodLights[i].GetComponent<Light>().color = Color.Lerp(edenMoodLightsColor1, edenMoodLightsColor2, timeToFadeBackColor * Time.deltaTime);
		}	
	}

	public void MoodLightBright() 
	{
		for (int i = 0; i < edenMoodLights.Length; i++)
        {
            edenMoodLights[i].GetComponent<Light>().color = Color.Lerp(edenMoodLightsColor2, edenMoodLightsColor1, timeToFadeBackColor * Time.deltaTime);
        }	
	}
}
