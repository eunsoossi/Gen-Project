using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

	public void SceneSwitcher1() 
	{
		SceneManager.LoadScene(1);
	}

	public void SceneSwitcher2()
	{
		SceneManager.LoadScene(0);
	}
}
