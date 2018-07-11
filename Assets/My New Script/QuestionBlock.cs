using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionBlock : MonoBehaviour {

	// 텍스트 띄우기 위한 값들
	public Text myText;
	public float timeToFadeText;
	public bool displayInfo = false;
	// ___________________________________________________

	// 블럭 사라짐 / 생김 효과
	public bool canFadeBlock;
	// private Color alphaColor;
	// private Color alphaColorReset;
	public float timeToFadeBlock;
	// ___________________________________________________

	public AudioSource blockClickSound;
	private int shaking = 0;
	private int shakingOff = 0;

	[SerializeField]
	private float shakeAmt;
	[SerializeField]
	private float xPosGap;


	void Start() 
	{
		// alphaColor = GetComponent<MeshRenderer>().material.color;
        // alphaColor.a = 0;
		// alphaColorReset = GetComponent<MeshRenderer>().material.color;
		// alphaColorReset.a = 1;
	}


    public void ChangeBible(string bible)
    {	
        myText = GameObject.Find(bible).GetComponent<Text>();
        myText.color = Color.clear;
    }

    private void Update() 
	{
		FadeText();

		// FadeBlock();

		if(shaking == 1)
		{
			Vector3 newPos = Random.insideUnitCircle * (Time.deltaTime * shakeAmt);
			newPos.y = transform.position.y;
			newPos.z = transform.position.z;

			transform.position = newPos + new Vector3(xPosGap, 0, 0);
		}
	}

	public void ShakeMe() 
	{	
		StartCoroutine("ShakeNow");
	}
	IEnumerator ShakeNow() 
	{
		Vector3 originalPos = transform.position;

		if(shaking == 0)
        {
            blockClickSound = GetComponent<AudioSource>();
            blockClickSound.Play();
			DisplayText();
            shaking = 1;
            shakingOff = shakingOff + 1;
        }
        if (shaking == 2) 
		{	
			DisplayText();
			shaking = 3;
		}

		yield return new WaitForSeconds(0.4f);

		if(shakingOff % 2 != 0) 
		{
			shaking = 2;
			transform.position = originalPos;
			shakingOff = shakingOff + 1;
			if(shakingOff > 10) {
				shakingOff = 0;
			}
		}

		if(shaking == 3) 
		{
			shaking = 0;
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

	public void PageButtonClickReset()
	{
		shaking = 0;
	}


// 	public void FadeBlock() 
// 	{	
// 		if(canFadeBlock)
// 		{	
// 			GetComponent<MeshRenderer>().material.color = Color.Lerp(GetComponent<MeshRenderer>().material.color, alphaColor, timeToFadeBlock * Time.deltaTime);
// 		}
// 		else
// 		{
// 			GetComponent<MeshRenderer>().material.color = Color.Lerp(GetComponent<MeshRenderer>().material.color, alphaColorReset, timeToFadeBlock * Time.deltaTime);
// 		}
		
// 	}
}
