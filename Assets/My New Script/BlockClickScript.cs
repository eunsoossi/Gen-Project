using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
// using UnityEngine.UI;


public class BlockClickScript : MonoBehaviour 
{
	public Camera guiCam;


	[SerializeField]
	private string blockName;

	void Update () 
	{
		if(Input.GetMouseButtonDown(0)) 
		{	
			Ray ray = guiCam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit; 
			
			if(Physics.Raycast(ray, out hit)) 
			{				
				if(hit.transform.name == blockName) 
				{	
					ShakeThisObject(hit.collider.gameObject);	
				}
			}
		}
	}

	void ShakeThisObject(GameObject shakeObject) 
	{
		shakeObject.GetComponent<QuestionBlock>().ShakeMe();
	}
}
