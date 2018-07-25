using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextFade : MonoBehaviour {

	// 텍스트 띄우기 위한 값들
	public TextMeshProUGUI myText;
	public string titleName;
	public float timeToFadeText;
	public bool displayInfo = false;
	// ___________________________________________________

	void Start() 
	{
		myText = GameObject.Find(titleName).GetComponent<TextMeshProUGUI>();
	}
	

	void Update() 
	{
		FadeText();
	}


	// private void DisplayTitle()
    // {
    //     // 성경 텍스트 페이드
    //     if (displayInfo == true)
    //     {
    //         displayInfo = false;
    //     }
    //     else
    //     {
    //         displayInfo = true;
    //     }
    // }

    public void FadeText() 
	{
		if(displayInfo) 
		{
			myText.color = Color.Lerp(myText.color, Color.white, timeToFadeText * Time.deltaTime);
		}
		else 
		{
			myText.color = Color.Lerp(myText.color, Color.clear, timeToFadeText * Time.deltaTime);
		}
	}

}
