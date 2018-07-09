using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


	// 제목 달기
	public TextFade originalMan;
	public TextFade originalProblem;



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

		// 제목달기
		originalMan = GameObject.Find("OriginalMan").GetComponent<TextFade>();
		originalProblem = GameObject.Find("OriginalProblem").GetComponent<TextFade>();
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
                    originalMan.displayInfo = false;
					LeaveGod();
                }
            }
		}
	}

    private void LeaveGod()
    {
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
		yield return new WaitForSeconds(2.5f);
		audioDrugAddictLight.Play();
		yield return new WaitForSeconds(0.4f);
		edenSpotlight.enabled = true;
		yield return new WaitForSeconds(0.3f);
		audioLivingGodScary.Play();
		originalProblem.displayInfo = true;
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
		yield return new WaitForSeconds(2f);
		mainCamBackScript.backColorOn = false;
	}
}
