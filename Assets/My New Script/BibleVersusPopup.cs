using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BibleVersusPopup : MonoBehaviour {

	// 텍스트 띄우기 위한 값들
	public TextMeshProUGUI myText;

	public string bibleName;
	public float timeToFadeText;
	public bool displayInfo = false;

	// ___________________________________________________


	private void Start() 
	{
		// AudioSource[] audios = GetComponents<AudioSource>();
		// biblePopUp = audios[0];
		// biblePopDown = audios[1];

		myText = GameObject.Find(bibleName).GetComponent<TextMeshProUGUI>();
		myText.color = Color.clear;

	}


    // public void ChangeBible(string bible)
    // {	
	// 	myText = GameObject.Find(bible).GetComponent<Text>();
	// 	myText.color = Color.clear;
	// }

	
    


    private void Update() 
	{
		FadeText();
	}


	// public void ClickMe() 
	// {	
	// 	StartCoroutine("FadeNow");
	// }
	// IEnumerator FadeNow() 
	// {
	// 	yield return new WaitForSeconds(0.4f);
	// 	if(popState == 0) 
	// 	{
    //     	biblePopUp.Play();
	// 		DisplayText();
	// 		popState += 1;
	// 	}
	// 	else
	// 	{
    //     	biblePopDown.Play();
	// 		DisplayText();
	// 		popState = 0;
	// 	}
	// }



    // private void DisplayText()
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

    void FadeText() 
	{
		if(displayInfo) 
		{
			myText.color = Color.Lerp(myText.color, Color.white, timeToFadeText * Time.deltaTime);
			Invoke("TextBye", 6);
		}
		else
		{
			myText.color = Color.Lerp(myText.color, Color.clear, timeToFadeText * Time.deltaTime);
		}
	}

	void TextBye()
	{
		displayInfo = false;
	}


	public void TextByeBye()
	{
		CancelInvoke("TextBye");
	}

	// public void BibleVersusReset()
	// {
	// 	if(popState != 0)
	// 	{
	// 		biblePopDown.Play();
	// 	}
	// 	displayInfo = false;
	// 	popState = 0;
	// }
}
