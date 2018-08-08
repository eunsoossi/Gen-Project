using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class CamControlManager : MonoBehaviour {
	
	// 성경구절 상태 변환
	public GameObject bibleVersus;
	public BibleButtonClickManager bibleClickManager;
	private GameObject[] bibleTurnOff;
	


	// 제목 설정
	public TextFade god;
	public TextFade originalMan;
	public TextFade originalProblem;
	public TextFade problemsOfMan;
	public TextFade theWay;

	
	// 전체 버튼 on off
	private GameObject[] allUIOnOff;


	// 달리캠 컨트롤 불러오기
	public PlayableDirector playerabkeDirector;

	public Camera mainCamera;

	// Light On / Off	
	public Light gameAddictLight;
	public Light drugAddictLight;
	public Light hospitalLight;
	public Light edenSpotlight;
	public GameObject edenLights;
	public GameObject idolLights;
	public GameObject gameAddictLightS;
	// public GameObject drugAddictLightS;
	// public GameObject hospitalLightS;
	public GameObject deadLights;
	public GameObject christLights;


	// 에덴동산 회전시키기
	public GameObject edenPivot;

	// 선악과 버튼 on off
	public GameObject mainTree;
	public GameObject mainTreeOutline;
	public CapsuleCollider forbiddenFruitsTree;
	public ButtonTree buttonTree;

	// 선악과 아웃라인 그리기
	public Outline outLineForTree;
	public bool outlineColorOnTree = false;
	public Color treeOutlineColor1;
	public Color treeOutlineColor2;

	// 십자가 아웃라인 그리기
	public GameObject CrossOutline;
	public Outline outLineForCross;
	public bool outlineColorOnCross = false;
	public Color crossOutlineColor1;
	public Color crossOutlineColor2;
	


	// 버추어 카메라 POV 리셋하기
	private GameObject[] cmPOVreset;

	// 버추어 카메라 불러오기
	public GameObject sunNMoonCam;
	public GameObject edenCam;
	public GameObject idolCam;
	public GameObject gameAddictCam;
	public GameObject drugAddictCam;
	public GameObject hosptialCam;
	public GameObject deadCam;
	public GameObject threeJobsCam;

	public GameObject edenSound;

	public GameObject gameAddictSpotlight;
	public GameObject drugAddictSpotlight;
	public GameObject hospitalSpotlight;
	

	// 십자가 페이드 인 앤 아웃
	public GameObject cross;
	public CanvasGroup prayerPanelRaycast;
	public GameObject cross2;



	AudioSource audioSee;
	AudioSource audioEden;
	AudioSource audioIdol;
	AudioSource audioGameAddict;
	AudioSource audioGameAddictLight;
	AudioSource audioDrugAddict;
	AudioSource audioDrugAddictLight;
	AudioSource audioHospital;
	AudioSource audioHospitalLight;
	AudioSource audioDead;
	AudioSource audioChrist;
	
	public Animator anim_EdenRotation;
	public Animator anim_CrossFade;
	public Animator anim_CrossFade2;

	// 카메라 페이지 넘기기
	private int trig = 0;
	private int addNum = 1;
	private int subNum = -1;
	private bool off = false;
	private bool on = true;
	public bool treeButtonActive = false;


	// 메인카메라 레이어(컬링마스크) 설정
	int cullingLayerDefault = 0;
	int cullingLayerEden = 8;
	int cullingLayerSunNMoon = 9;
	int cullingLayerThreeJobs = 10;
	int cullingLayerIdol = 11;
	int cullingLayerGameAddict = 12;
	int cullingLayerDrugAddict = 13;
	int cullingLayerHospital = 14;
	int cullingLayerDead = 15;
	int cullingLayerHeartCross = 16;



	void Start () 
	{
		// 성경구절 불러오기
		bibleClickManager = bibleVersus.GetComponent<BibleButtonClickManager>();
		bibleClickManager.BibleState(0);
		bibleTurnOff = GameObject.FindGameObjectsWithTag("BibleTurnOff");

		// 버튼들 모두 불러오기
		allUIOnOff = GameObject.FindGameObjectsWithTag("ButtonOnOff");

		// 버추어 카메라 POV 리셋 설정
		cmPOVreset = GameObject.FindGameObjectsWithTag("VirtualCam");

		// 카메라 시작 시점. 해와 달 마스크
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerSunNMoon); 

		audioSee = edenCam.GetComponent<AudioSource>();
		audioEden = edenSound.GetComponent<AudioSource>();
		audioIdol = idolCam.GetComponent<AudioSource>();
		audioGameAddict = gameAddictCam.GetComponent<AudioSource>();
		audioGameAddictLight = gameAddictSpotlight.GetComponent<AudioSource>();
		audioDrugAddict = drugAddictCam.GetComponent<AudioSource>();
		audioDrugAddictLight = drugAddictSpotlight.GetComponent<AudioSource>();
		audioHospital = hosptialCam.GetComponent<AudioSource>();
		audioHospitalLight = hospitalSpotlight.GetComponent<AudioSource>();
		audioDead = deadCam.GetComponent<AudioSource>();
		audioChrist = threeJobsCam.GetComponent<AudioSource>();

		anim_EdenRotation = edenPivot.GetComponent<Animator>();
		anim_EdenRotation.SetBool("Rotate", true);
		anim_CrossFade = cross.GetComponent<Animator>();
		anim_CrossFade2 = cross2.GetComponent<Animator>();
		anim_CrossFade.SetBool("Fade", false);
		anim_CrossFade2.SetBool("Fade", false);

		//영접기도문 켜고끄기
		prayerPanelRaycast = GameObject.Find("PrayerPanel").GetComponent<CanvasGroup>();


		
		gameAddictLight = gameAddictLight.GetComponent<Light>();
		gameAddictLight.enabled = false;
		drugAddictLight = drugAddictLight.GetComponent<Light>();
		drugAddictLight.enabled = false;
		hospitalLight = hospitalLight.GetComponent<Light>();
		hospitalLight.enabled = false;
		edenSpotlight = GameObject.Find("Eden Spotlight").GetComponent<Light>();

		idolLights.SetActive(false);
		deadLights.SetActive(false);
		christLights.SetActive(false);
		gameAddictLightS.SetActive(false);



		// 제목 셋팅 시작
		god = GameObject.Find("God").GetComponent<TextFade>();
		originalMan = GameObject.Find("OriginalMan").GetComponent<TextFade>();
		originalMan.displayInfo = false;
		originalProblem = GameObject.Find("OriginalProblem").GetComponent<TextFade>();
		originalProblem.displayInfo = false;
		problemsOfMan = GameObject.Find("ProblemsOfMan").GetComponent<TextFade>();
		problemsOfMan.displayInfo = false;
		theWay = GameObject.Find("TheWay").GetComponent<TextFade>();
		theWay.displayInfo = false;


		// 선악과 버튼 셋팅
		buttonTree = mainTree.GetComponent<ButtonTree>();
		outLineForTree = mainTreeOutline.GetComponent<Outline>();

		// 선악과 콜라이더 on off
		forbiddenFruitsTree = mainTree.GetComponent<CapsuleCollider>();

		// 십자가 아웃라인 셋팅
		outLineForCross = CrossOutline.GetComponent<Outline>();


		// 페이지 시작
		TurnSunNMoonOn();
	}

	void Update() 
	{
		OutlineColorChange();	
	}



	public void RightClicked ()
    {
		// 성경구절 페이지 넘길때 끄기
		for (int i = 0; i < bibleTurnOff.Length; i++)
        {
			if(bibleTurnOff[i].GetComponent<BibleVersusPopup>().displayInfo == true)
			{
				bibleTurnOff[i].GetComponent<BibleVersusPopup>().displayInfo = false;
			}
        }

        // 버추어 카메라 POV 리셋
        for (int i = 0; i < cmPOVreset.Length; i++)
        {
            cmPOVreset[i].GetComponent<CMZoomCtrl>().POVreset();
        }

        off = false;

		Debug.Log("카메라 몇번?" + trig);
		if (trig != 2)
		{
			trig = trig + addNum;
		}
		else if (trig == 2 && edenSpotlight.enabled == true)
		{
			trig = trig + addNum;
		}
		else
		{
			return;
		}

        switch (trig)
        {
            case 1:
                sunNMoonCam.SetActive(off);
                TurnSeeOn();
                TurnSunNMoonOff();
                break;

            case 2:
                anim_EdenRotation.SetBool("Rotate", false);
                TurnSeeOff();
                TurnEdenOn();
                break;

            case 3:
                edenCam.SetActive(off);
                TurnEdenOff();
                TurnIdolOn();
                break;

            case 4:
                idolCam.SetActive(off);
                TurnIdolOff();
                TurnGameAddictOn();
                break;

            case 5:
                gameAddictCam.SetActive(off);
                TurnGameAddictOff();
                TurnDrugAddictOn();
                break;

            case 6:
                drugAddictCam.SetActive(off);
                TurnDrugAddictOff();
                TurnHospitalOn();
                break;

            case 7:
                hosptialCam.SetActive(off);
                TurnHospitalOff();
                TurnDeadOn();
                break;

            case 8:
                deadCam.SetActive(off);
                TurnDeadOff();
                TurnChristOn();
                christLights.SetActive(true);
                break;

            case 9:
                threeJobsCam.SetActive(off);
				// 영접기도문을 위해서 나머지 UI 모두 끄기
                for (int i = 0; i < allUIOnOff.Length; i++)
                {
                    allUIOnOff[i].SetActive(false);
                }
                TurnHeartCrossOn();
                DollyCamPlay();
                break;

            case 10:
                if (trig >= 10)
                    trig = 9;
					Debug.Log("캠넘버?  " + trig);
                break;
        }
    }

    public void LeftClicked () 
	{
		// 성경구절 페이지 넘길때 끄기
		for (int i = 0; i < bibleTurnOff.Length; i++)
        {
			if(bibleTurnOff[i].GetComponent<BibleVersusPopup>().displayInfo == true)
			{
				bibleTurnOff[i].GetComponent<BibleVersusPopup>().displayInfo = false;
			}
        }
		// 버추어 카메라 POV 리셋
		for(int i = 0; i < cmPOVreset.Length; i++)
		{
            cmPOVreset[i].GetComponent<CMZoomCtrl>().POVreset();
        }


		Debug.Log("카메라 몇번?" + trig);
		trig = trig + subNum;


		switch (trig) {
			case 0:
				sunNMoonCam.SetActive(on);
				TurnSeeOff();
				TurnSunNMoonOn();
				break;

			case 1:
				anim_EdenRotation.SetBool("Rotate", true);
				TurnEdenOff();
				TurnSeeOn();
				break;

			case 2:
				edenCam.SetActive(on);
				TurnIdolOff();
				TurnEdenOn();
				break;

			case 3:
				idolCam.SetActive(on);
				TurnGameAddictOff();
				TurnIdolOn();
				break;

			case 4:
				gameAddictCam.SetActive(on);
				TurnGameAddictOn();
				TurnDrugAddictOff();
				break;

			case 5:
				drugAddictCam.SetActive(on);
				TurnDrugAddictOn();
				TurnHospitalOff();
				break;

			case 6:
				hosptialCam.SetActive(on);
				TurnHospitalOn();
				TurnDeadOff();
				break;

			case 7:
				deadCam.SetActive(on);
				TurnDeadOn();
				TurnChristOff();
				christLights.SetActive(false);
				break;

			case 8:
				threeJobsCam.SetActive(on);
				TurnChristOn();
				TurnHeartCrossOff();
				DollyCamPlayOff();
				// 영접기도문을 위해서 나머지 UI 모두 끄기
				for(int i = 0; i < allUIOnOff.Length; i++)
				{
             		allUIOnOff[i].SetActive(true);
         		}
				break;

			default:
				trig = 0;
				break;
		}
	}



	// 해와 달 끄고 켜기
	void TurnSunNMoonOff() 
	{
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerSunNMoon) | (1 << cullingLayerEden); 
		// FadeBlockOnOff(1);
	}

	void TurnSunNMoonOn() 
	{
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerSunNMoon) | (1 << cullingLayerEden);
		bibleClickManager.BibleState(0);
		StartCoroutine("WaitForSunNMoonOn");
		god.displayInfo = true;
	}
	IEnumerator WaitForSunNMoonOn() 
	{
		yield return new WaitForSeconds(2f);
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerSunNMoon) | (1 << cullingLayerEden);
		// FadeBlockOnOff(0);
	}

	// 바다 끄고 켜기
	void TurnSeeOff() {
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerEden) | (1 << cullingLayerSunNMoon);  
		// StopCoroutine("WaitForEdenOn");
		audioSee.Stop();
		god.displayInfo = false;
	}
	void TurnSeeOn() {
		audioSee.Play();
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerSunNMoon) | (1 << cullingLayerEden); 
		originalMan.displayInfo = false;
		originalProblem.displayInfo = false;
		god.displayInfo = true;
		bibleClickManager.BibleState(1);
		StartCoroutine("WaitForSeeOn");
	}
	IEnumerator WaitForSeeOn() {
		yield return new WaitForSeconds(1f);
		// FadeBlockOnOff(0);
	}

	// 에덴 끄고 켜기
	void TurnEdenOff() {
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerEden) | (1 << cullingLayerSunNMoon);  
		// StopCoroutine("WaitForEdenOn");
		edenLights.SetActive(false);
		audioEden.Stop();
		// bibleButton.canFadeBlock = true;
		forbiddenFruitsTree.enabled = false;
		originalProblem.displayInfo = false;
		originalMan.displayInfo = false;
	}
	void TurnEdenOn() {
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerSunNMoon) | (1 << cullingLayerEden); 
		edenLights.SetActive(true);
		forbiddenFruitsTree.enabled = true;
		problemsOfMan.displayInfo = false;
		if(edenSpotlight.enabled == false)
		{
			audioEden.Play();
			originalMan.displayInfo = true;
			originalProblem.displayInfo = false;
			bibleClickManager.BibleState(2);
			StartCoroutine("WaitForEdenOn");
		}
		else
		{
			originalProblem.displayInfo = true;
			bibleClickManager.BibleState(3);
			outlineColorOnTree = false;
		}
	}
	IEnumerator WaitForEdenOn() {
		yield return new WaitForSeconds(1f);
		outLineForTree.enabled = true;
		outlineColorOnTree = true; 
	}


	void OutlineColorChange()
	{
		if (outlineColorOnTree)
		{
			outLineForTree.outlineColor = Color.Lerp(treeOutlineColor1, treeOutlineColor2, Mathf.PingPong(Time.time, 1));
		}

		if (outlineColorOnCross)
		{
			outLineForCross.outlineColor = Color.Lerp(crossOutlineColor1, crossOutlineColor2, Mathf.PingPong(Time.time, 2));
		}
	}


	// 우상 끄고 켜기
	void TurnIdolOff() {
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerIdol) | (1 << cullingLayerEden);
		audioIdol.Stop();
		idolLights.SetActive(false);
		StopCoroutine("WaitForIdolOn");
		// FadeBlockOnOff(1);
	}
	void TurnIdolOn() {
		audioIdol.Play();
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerEden) | (1 << cullingLayerIdol) | (1 << cullingLayerSunNMoon); 
		idolLights.SetActive(true);
		bibleClickManager.BibleState(4);
		StartCoroutine("WaitForIdolOn");
	}
	IEnumerator WaitForIdolOn() {
		yield return new WaitForSeconds(1f);
		originalProblem.displayInfo = false;
		originalMan.displayInfo = false;
		problemsOfMan.displayInfo = true;
		yield return new WaitForSeconds(1f);
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerIdol); 
		// FadeBlockOnOff(0);
	}

	// 게임중독자 조명 및 사운드 끄고 켜기
	void TurnGameAddictOff() {
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerGameAddict) | (1 << cullingLayerIdol); 
		StopCoroutine("WaitForGameAddictOn");
		audioGameAddict.Stop();
		audioGameAddictLight.Stop();
		gameAddictLight.enabled = false;
		gameAddictLightS.SetActive(false);
		// FadeBlockOnOff(1);
	}
	void TurnGameAddictOn() {
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerIdol) | (1 << cullingLayerGameAddict); 
		problemsOfMan.displayInfo = true;
		bibleClickManager.BibleState(5);
		StartCoroutine("WaitForGameAddictOn");
	}
	IEnumerator WaitForGameAddictOn() {
		yield return new WaitForSeconds(2f);
		gameAddictLightS.SetActive(true);
		audioGameAddictLight.Play();
		gameAddictLight.enabled = true;
		yield return new WaitForSeconds(0.5f);
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerGameAddict);
		// FadeBlockOnOff(0);
		yield return new WaitForSeconds(0.5f);
		audioGameAddict.Play();
	}

	// 약물중독자(정신병자) 조명 및 사운드 끄고 켜기
	void TurnDrugAddictOff() {
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerDrugAddict) | (1 << cullingLayerGameAddict);
		StopCoroutine("WaitForDrugAddictOn");
		audioDrugAddict.Stop();
		audioDrugAddictLight.Stop();
		drugAddictLight.enabled = false;
		// drugAddictLightS.SetActive(false);
		problemsOfMan.displayInfo = true;
		// FadeBlockOnOff(1);
	}
	void TurnDrugAddictOn() {
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerGameAddict) | (1 << cullingLayerDrugAddict);
		bibleClickManager.BibleState(6);
		StartCoroutine("WaitForDrugAddictOn");
	}
	IEnumerator WaitForDrugAddictOn() {
		yield return new WaitForSeconds(1f);
		audioDrugAddictLight.Play();
		// drugAddictLightS.SetActive(true);
		yield return new WaitForSeconds(0.2f);
		audioDrugAddict.Play();
		drugAddictLight.enabled = true;
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerDrugAddict);
		// FadeBlockOnOff(0);
	}

	// 병원 조명 및 사운드 끄고 켜기
	void TurnHospitalOff() {
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerDrugAddict) | (1 << cullingLayerHospital);
		StopCoroutine("WaitForHospitalOn");
		audioHospital.Stop();
		audioHospitalLight.Stop();
		hospitalLight.enabled = false;
		// hospitalLightS.SetActive(false);
		// FadeBlockOnOff(1);
	}
	void TurnHospitalOn() {
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerDrugAddict) | (1 << cullingLayerHospital);
		problemsOfMan.displayInfo = true;
		bibleClickManager.BibleState(7);
		StartCoroutine("WaitForHospitalOn");
	}
	IEnumerator WaitForHospitalOn() {
		yield return new WaitForSeconds(1.5f);
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerHospital);
		audioHospitalLight.Play();
		hospitalLight.enabled = true;
		// hospitalLightS.SetActive(true);
		// FadeBlockOnOff(0);
		yield return new WaitForSeconds(0.6f);
		audioHospital.Play();
		// biblePopup.SendMessage("ChangeBible", "Acts848");
	}

	// 에덴 끄고 켜기
	void TurnDeadOff() {
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerDead) | (1 << cullingLayerHospital); 
		deadLights.SetActive(false);
		StopCoroutine("WaitForDeadOn");
		audioDead.Stop();
		// FadeBlockOnOff(1);
	}
	void TurnDeadOn() {
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerHospital) | (1 << cullingLayerDead); 
		audioDead.Play();
		deadLights.SetActive(true);
		bibleClickManager.BibleState(8);
		StartCoroutine("WaitForDeadOn");
	}
	IEnumerator WaitForDeadOn() {
		yield return new WaitForSeconds(2f);
		// biblePopup.SendMessage("ChangeBible", "Exo205");
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerDead);
		problemsOfMan.displayInfo = true;
		// FadeBlockOnOff(0);
	}

	// 3직분 끄고 켜기
	void TurnChristOff() {
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerDead) | (1 << cullingLayerThreeJobs); 
		theWay.displayInfo = false;
		StopCoroutine("WaitForChristOn");
	}
	void TurnChristOn() {
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerDead) | (1 << cullingLayerThreeJobs); 
		buttonTree.ChristSolved();
		problemsOfMan.displayInfo = false;
		audioChrist.Stop();
		bibleClickManager.BibleState(9);
		StartCoroutine("WaitForChristOn");
	}
	IEnumerator WaitForChristOn() {
		yield return new WaitForSeconds(1f);
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerThreeJobs); 
		theWay.displayInfo = true;
		audioChrist.Play();

	}

	// 영접 끄고 켜기
	void TurnHeartCrossOff() {
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerThreeJobs) | (1 << cullingLayerHeartCross); 
		prayerPanelRaycast.blocksRaycasts = false;
	}
	void TurnHeartCrossOn() {
		mainCamera.cullingMask = (1 << cullingLayerDefault) | (1 << cullingLayerThreeJobs) | (1 << cullingLayerHeartCross); 
		theWay.displayInfo = false;
		prayerPanelRaycast.blocksRaycasts = true;
		StartCoroutine("WaitForCrossOn");
	}
	IEnumerator WaitForCrossOn() {
		yield return new WaitForSeconds(5f);
		outLineForCross.enabled = true;
		outlineColorOnCross = true;
	}

	


	// 달리캠 플레이 컨트롤용 함수
	void DollyCamPlayOff() {
		playerabkeDirector.Stop();
		anim_CrossFade.SetBool("Fade", false);
		anim_CrossFade2.SetBool("Fade", false);
	}
	void DollyCamPlay() {
		playerabkeDirector.Play();
		StartCoroutine("WaitForDollyCamOn");
	}
	IEnumerator WaitForDollyCamOn() {
		yield return new WaitForSeconds(4f);
		anim_CrossFade.SetBool("Fade", true);
		anim_CrossFade2.SetBool("Fade", true);
	}
}
