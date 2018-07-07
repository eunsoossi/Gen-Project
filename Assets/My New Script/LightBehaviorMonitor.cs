using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviorMonitor : MonoBehaviour {

	private Light thisLight;
	private Color originalColor;
	private float timePassed;
	private float changeValue;

	// public float controlMonitor1 = 0.2f;
	// public float controlMonitor2 = 0.7f;

	// Use this for initialization
	void Start ()
    {
        LightColorSet();
    }

    private void LightColorSet()
    {
        thisLight = this.GetComponent<Light>();

        if (thisLight != null)
        {
            originalColor = thisLight.color;
        }
        else
        {
            enabled = false;
            return;
        }

        changeValue = 0;
        timePassed = 0;
    }

    // Update is called once per frame
    void Update ()
    {
        LightTimmingCalc();
    }

    private void LightTimmingCalc()
    {
        timePassed = Time.time;
        timePassed = timePassed - Mathf.Floor(timePassed);

        thisLight.color = originalColor * CalculateChange();
    }

    private float CalculateChange () {
		changeValue = -Mathf.Sin(timePassed * 12 * Mathf.PI) * -0.05f + 0.9f;
		return changeValue;
	}
}
