using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollNormalPos : MonoBehaviour 
{
	public ScrollRect myScrollRect;
	// Use this for initialization
	public void ScrollReset () 
	{
		myScrollRect.verticalNormalizedPosition = 1f;
	}
}
