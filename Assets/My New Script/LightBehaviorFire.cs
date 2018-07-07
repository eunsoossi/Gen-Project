using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviorFire : MonoBehaviour {

	private Light thisLight;
	private Color originalColor;
	private float timePassed;
	private float changeValue;

	// Use this for initialization
	void Start () {

		thisLight = this.GetComponent<Light>();

		if(thisLight != null) {
			originalColor = thisLight.color;
		}
		else {
			enabled = false;
			return;
		}

		changeValue = 0;
		timePassed = 0;
	}
	
	// Update is called once per frame
	void Update () {

		timePassed = Time.time;
		timePassed = timePassed - Mathf.Floor(timePassed);

		thisLight.color = originalColor * CalculateChange();
	}

	private float CalculateChange () {
		changeValue = -Mathf.Sin(timePassed * 12 * Mathf.PI) * Random.Range(0.08f,0.2f) + 0.95f;
		return changeValue;
	}
}
