using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdenController : MonoBehaviour {

	public GameObject edenPivot;
	public Animator anim;


	void Start() {
		anim = edenPivot.GetComponent<Animator>();
	}
	public void LeftClicked() {

		anim.SetBool("Rotate", false);
	}

	public void RightClicked() {

		anim.SetBool("Rotate", true);
	}
}
