using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonTree : MonoBehaviour {

	// 화이트디졸브 애니메이션
	Animator animWhiteDissolve;
	public GameObject whiteDissolve;
	// 화이트 디졸브 사운드 설정
	AudioSource whiteDissolveSound;

	// 카메라 배경색 블랙으로 바꾸기
	public ChangeBackColor mainCamBackScript;
	public GameObject mainCam;


	// Eden 선악과 스팟라이트 켜기
	public GameObject forbiddenFruit;
	public Light edenSpotlight;
	public Light edenDirectlight;
		// 오디오소스
		public AudioSource audioDrugAddictLight;
		public AudioSource audioEden;
		AudioSource audioLivingGodScary;
	
	// Eden 무드라이트 조절하기
	public EdenMoodLightController edenMoodLightControl;

	// 선악과 아웃라인 정지시키기
	public GameObject mainTreeOutline;
	public Outline outLineForTree;


	// 제목 달기
	public TextFade god;
	public TextFade originalMan;
	public TextFade originalProblem;
	public TextFade problemsOfMan;

	// 성경구절 나무버튼과 함께 끄기
	public BibleVersusPopup gen0128;
	public BibleVersusPopup gen0315;
	public BibleVersusPopup eph22;
	public BibleButtonClickManager bibleClickManager;


    void Start() 
	{
		// 화이트 디졸브
        animWhiteDissolve = whiteDissolve.GetComponent<Animator>();
		whiteDissolveSound = whiteDissolve.GetComponent<AudioSource>();

		// 카메라 백그라운드 컬러 
		mainCamBackScript = mainCam.GetComponent<ChangeBackColor>();

		// 에덴 선악과
		edenSpotlight = forbiddenFruit.GetComponent<Light>();
		edenDirectlight = GameObject.Find("Directional Light for Eden").GetComponent<Light>();
		audioDrugAddictLight = GameObject.Find("DrugAddictSpotlight").GetComponent<AudioSource>();
		audioEden = GameObject.Find("EdenSoundPlayer").GetComponent<AudioSource>();
		audioLivingGodScary = GetComponent<AudioSource>();
		edenMoodLightControl = GameObject.Find("EdenMoodLight").GetComponent<EdenMoodLightController>();
		// 선악과 아웃라인 끄기
		outLineForTree = mainTreeOutline.GetComponent<Outline>();

		// 제목달기
		god = GameObject.Find("God").GetComponent<TextFade>();
		originalMan = GameObject.Find("OriginalMan").GetComponent<TextFade>();
		originalProblem = GameObject.Find("OriginalProblem").GetComponent<TextFade>();
		problemsOfMan = GameObject.Find("ProblemsOfMan").GetComponent<TextFade>();
    
		// 성경구절 나무버튼과 함께 끄기
		gen0128 = GameObject.Find("Gen0128").GetComponent<BibleVersusPopup>();
		gen0315 = GameObject.Find("Gen0315").GetComponent<BibleVersusPopup>();
		eph22 = GameObject.Find("Eph22").GetComponent<BibleVersusPopup>();
		bibleClickManager = GameObject.Find("BibleVersus").GetComponent<BibleButtonClickManager>();
	}


	void Update() 
	{	
		if(Input.GetMouseButtonDown(0)) 
		{	
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
		
			if(Physics.Raycast(ray, out hit)) 
			{
				if(hit.transform.name == "tree-baobab")
                {
					outLineForTree.enabled = false;
                    originalMan.displayInfo = false;
					gen0128.displayInfo = false;
					LeaveGod();
                }
            }
		}
	}

    private void LeaveGod()
    {	
		bibleClickManager.BibleState(3);
		whiteDissolveSound.Play();
        animWhiteDissolve.SetBool("ClickTree", true);
        audioEden.Stop();
        edenMoodLightControl.MoodLightDark();
        if (!mainCamBackScript.backColorOn)
        {
            mainCamBackScript.backColorOn = true;
            if (edenSpotlight.enabled == false)
            {	
                StartCoroutine("WaitForEdenSpotlight");
            }
        }
    }
    IEnumerator WaitForEdenSpotlight() 
	{
		yield return new WaitForSeconds(0.3f);
		edenDirectlight.enabled = false;			
		yield return new WaitForSeconds(1.7f);
		audioDrugAddictLight.Play();
		yield return new WaitForSeconds(0.4f);
		edenSpotlight.enabled = true;
		yield return new WaitForSeconds(0.4f);
		if(god.displayInfo == false && problemsOfMan.displayInfo == false)
		{
			originalProblem.displayInfo = true;	
		}
		audioLivingGodScary.Play();
	}

	public void ChristSolved() 
	{	
		animWhiteDissolve.SetBool("ClickTree", false);
		audioLivingGodScary.Stop();
		audioDrugAddictLight.Stop();
		edenDirectlight.enabled = true;	
		edenSpotlight.enabled = false;
		edenMoodLightControl.MoodLightBright();
		StartCoroutine("WaitForBackColorOn");
	}
	IEnumerator WaitForBackColorOn()
	{
		yield return new WaitForSeconds(1.4f);
		mainCamBackScript.backColorOn = false;
	}
}
