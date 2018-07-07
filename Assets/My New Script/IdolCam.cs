using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdolCam : MonoBehaviour {

	float setClick = 1;
	float setClickAgain = -1;

	// Use this for initialization
	private void Start() {

		gameObject.SetActive(false);
	}

	public void forClick() {

		setClick = setClick * setClickAgain;

		if(setClick > 0) {
			gameObject.SetActive(true);
		}
		else if (setClick < 0) {
			gameObject.SetActive(false);
		}
	}
}
