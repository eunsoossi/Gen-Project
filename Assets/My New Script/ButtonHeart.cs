using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHeart : MonoBehaviour 
{
	public GameObject mainCam;

	// 영접기도문 패널 기능 on off
	public Button prayerPanel;
	public GameObject button;

	//스크롤 텍스트 위치 리셋을 위해 
	public ScrollNormalPos scrollReset;

	void Start() 
	{
		scrollReset = scrollReset.GetComponent<ScrollNormalPos>();
		// 영접기도문 패널 on off
		prayerPanel = button.GetComponent<Button>();
		prayerPanel.enabled = false;
	}
	void Update () 
	{
		if(Input.GetMouseButtonDown(0)) 
		{	
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
		
			if(Physics.Raycast(ray, out hit)) 
			{
				if(hit.transform.name == "Heart") 
				{	
					prayerPanel.enabled = true;
					mainCam.GetComponent<UIFader>().FadeIn();
					scrollReset.ScrollReset();
				}
			}
		}
	}
}
