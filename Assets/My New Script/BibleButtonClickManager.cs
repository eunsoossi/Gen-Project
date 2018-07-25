using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BibleButtonClickManager : MonoBehaviour {

	private int bibleButtonState;
	// 성경문구 팝업사운드
	public AudioSource[] biblePop;
		public AudioSource popUp;
		public AudioSource popDown;

	// 성경구절 띄우기
	public BibleVersusPopup gen0105;
	public BibleVersusPopup gen0120;
	public BibleVersusPopup gen0128;
	public BibleVersusPopup gen0315;
	public BibleVersusPopup eph22;
	public BibleVersusPopup john844;
	public BibleVersusPopup mat1128;
	public BibleVersusPopup acts848;
	public BibleVersusPopup exo205;
	public BibleVersusPopup rom58John38;

	void Start() 
	{	
		// 성경구절 팝업사운드
		biblePop = GetComponents<AudioSource>();
		popUp = biblePop[0];
		popDown = biblePop[1];
	}


	// 성경구절 상태 참조
	// gen0105 천지창조 = 0
	// gen0128 원래인간. 정복 = 1
	// gen0315 여자의 후손 = 2
	// eph22 사단 소속 = 3
	// john844 게임 중독= 4
	// mat1128 마약 중독 정신병 = 5
	// acts848 병원 = 6
	// exo205 죽음 이후 = 7
	public void BibleState(int bibleButtonStateChange)
	{
		bibleButtonState = bibleButtonStateChange;
	}


	
	public void BibleOn() 
	{
		switch (bibleButtonState)
		{
			case 0:
				if(gen0105.displayInfo == false)
				{
					gen0105.displayInfo = true;
					popUp.Play();
				}
				else
				{
					gen0105.displayInfo = false;
					popDown.Play();

				}
				break;

			case 1:
				if(gen0120.displayInfo == false)
				{
					gen0120.displayInfo = true;
					popUp.Play();
				}
				else
				{
					gen0120.displayInfo = false;
					popDown.Play();

				}
				break;

			case 2:
				if(gen0128.displayInfo == false)
				{
					gen0128.displayInfo = true;
					popUp.Play();
				}
				else
				{
					gen0128.displayInfo = false;
					popDown.Play();
				}
				break;
			
			case 3:
				if(gen0315.displayInfo == false)
				{
					gen0315.displayInfo = true;
					popUp.Play();
				}
				else
				{
					gen0315.displayInfo = false;
					popDown.Play();
				}
				break;

			case 4:
				if(eph22.displayInfo == false)
				{
					eph22.displayInfo = true;
					popUp.Play();
				}
				else
				{
					eph22.displayInfo = false;
					popDown.Play();
				}
				break;
			
			case 5:
				if(john844.displayInfo == false)
				{
					john844.displayInfo = true;
					popUp.Play();
				}
				else
				{
					john844.displayInfo = false;
					popDown.Play();
				}
				break;
			
			case 6:
				if(mat1128.displayInfo == false)
				{
					mat1128.displayInfo = true;
					popUp.Play();
				}
				else
				{
					mat1128.displayInfo = false;
					popDown.Play();
				}
				break;

			case 7:
				if(acts848.displayInfo == false)
				{
					acts848.displayInfo = true;
					popUp.Play();
				}
				else
				{
					acts848.displayInfo = false;
					popDown.Play();
				}
				break;

			case 8:
				if(exo205.displayInfo == false)
				{
					exo205.displayInfo = true;
					popUp.Play();
				}
				else
				{
					exo205.displayInfo = false;
					popDown.Play();
				}
				break;

			case 9:
				if(rom58John38.displayInfo == false)
				{
					rom58John38.displayInfo = true;
					popUp.Play();
				}
				else
				{
					rom58John38.displayInfo = false;
					popDown.Play();
				}
				break;

			default:
				break;
		}
	}
}
