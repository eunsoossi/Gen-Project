using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BibleVersusPopup : MonoBehaviour {

	// 텍스트 띄우기 위한 값들
	public Text myText;
	public float timeToFadeText;
	public bool displayInfo = false;
	// ___________________________________________________

	AudioSource biblePopUp;
	AudioSource biblePopDown;
	private int popState = 0;


	private void Start() 
	{
		AudioSource[] audios = GetComponents<AudioSource>();
		biblePopUp = audios[0];
		biblePopDown = audios[1];

	}


    public void ChangeBible(string bible)
    {	
        myText = GameObject.Find(bible).GetComponent<Text>();
        myText.color = Color.clear;
    }


    private void Update() 
	{
		FadeText();
	}


	public void ClickMe() 
	{	
		StartCoroutine("FadeNow");
	}
	IEnumerator FadeNow() 
	{
		yield return new WaitForSeconds(0.4f);
		if(popState == 0) 
		{
        	biblePopUp.Play();
			DisplayText();
			popState += 1;
		}
		else
		{
        	biblePopDown.Play();
			DisplayText();
			popState = 0;
		}
	}


    private void DisplayText()
    {	
        // 성경 텍스트 페이드
        if (displayInfo == true)
        {
            displayInfo = false;
        }
        else
        {
            displayInfo = true;
        }
    }

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


	public void BibleVersusReset()
	{
		if(popState != 0)
		{
			biblePopDown.Play();
		}
		displayInfo = false;
		popState = 0;
	}
}
