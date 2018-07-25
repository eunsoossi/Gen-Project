using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

	public GameObject loadingScreen;
	// public Slider slider;
	public Image imageCircleFill;
	public Text progressText;
	public Text explainText;

	public void LoadLevel(int sceneIndex)
	{
		StartCoroutine(LoadAsyncronously(sceneIndex));	
	}

	IEnumerator LoadAsyncronously(int sceneIndex)
	{
		AsyncOperation operation =  SceneManager.LoadSceneAsync(sceneIndex);

		loadingScreen.SetActive(true);

		while (!operation.isDone)
		{
			float progress = Mathf.Clamp01(operation.progress / .9f);

			imageCircleFill.fillAmount = progress;
			progressText.text = (int)(progress * 100f) + "%";
			explainText.text = "천지창조중....";
			Debug.Log(progressText.text);

			yield return null;
		}
	}
}
