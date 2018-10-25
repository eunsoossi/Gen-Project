using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;


public class LocalizationManager : MonoBehaviour
{
	public static LocalizationManager instance;
	private Dictionary<string, string> localizedText;
	private bool isReady = false;
	private bool transOk = false;
	private string missingTextString = "Localized text not found";

	// Use this for initialization
	void Awake ()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		// DontDestroyOnLoad (gameObject);
	}
		
	public void LoadLocalizedText (string fileName)
	{
		localizedText = new Dictionary<string, string> ();
		string filePath = Path.Combine (Application.streamingAssetsPath + "/", fileName);
		Debug.Log ("ABC" + filePath);

		if (File.Exists (filePath)) 
		{
			string dataAsJson = File.ReadAllText (filePath);
			LocalizationData loadedData = JsonUtility.FromJson<LocalizationData> (dataAsJson);

			for (int i = 0; i < loadedData.items.Length; i++) 
			{
				localizedText.Add (loadedData.items[i].key, loadedData.items[i].value);   
			}
			Debug.Log ("Data loaded, dictionary contains: " + localizedText.Count + " entries");
		}
		else 
		{
			Debug.LogError ("Cannot find file! named" + fileName);
		}

		isReady = true;
	}

	public void SetLanguage (string fileName)
	{
		if (Application.platform == RuntimePlatform.WindowsEditor)
		{
			LoadLocalizedText (fileName);
		}
		else if (Application.platform == RuntimePlatform.OSXEditor)
		{
			LoadLocalizedText (fileName);
			// StartCoroutine (LoadLocalizedTextOnAndroid(fileName));
			// LoadLocalizedTextOnAndroid (fileName);
		}
		else if (Application.platform == RuntimePlatform.Android)
		{
			// LoadLocalizedText (fileName);
			// StartCoroutine (LoadLocalizedTextOnAndroid(fileName)); 
			LoadLocalizedTextOnAndroid (fileName);
		}
		else
		{
			LoadLocalizedText (fileName);
		}
	}

	public void LoadLocalizedTextOnAndroid (string fileName)
	{
		localizedText = new Dictionary<string, string> ();
		string filePath;// = Path.Combine(Application.streamingAssetsPath, fileName);
		filePath = Path.Combine (Application.streamingAssetsPath + "/", fileName);
		string dataAsJson;

		if (filePath.Contains ("://") || filePath.Contains (":///")) 
		{
			// debugText.text += System.Environment.NewLine + filePath;
			// Debug.Log ("UNITY:" + System.Environment.NewLine + filePath);
			// UnityWebRequest www = UnityWebRequest.Get (filePath);
			// yield return www.SendWebRequest ();
			// dataAsJson = www.downloadHandler.text;
			// Debug.Log(www.downloadHandler.text);
			// Debug.Log("이프인가요?????");
			// Debug.Log(dataAsJson);
			WWW www = new WWW(filePath);
            while (!www.isDone) { }
			dataAsJson = www.text;
		} 
		else
		{
			dataAsJson = File.ReadAllText (filePath);
		}
		LocalizationData loadedData = JsonUtility.FromJson<LocalizationData> (dataAsJson);

		for (int i = 0; i < loadedData.items.Length; i++) 
		{
			localizedText.Add (loadedData.items[i].key, loadedData.items[i].value);
			// Debug.Log ("KEYS:" + loadedData.items [i].key);
			if (loadedData.items[i].key == "prayer")
			{
				transOk = true;
			}
		}
		isReady = true;
	}

	public string GetLocalizedValue (string key)
	{
		string result = missingTextString;
		if (localizedText.ContainsKey (key)) {
			result = localizedText [key];
		}

		return result;

	}

	public string GetLocalizedValue2 (string key)
	{
		string result = missingTextString;

		if (localizedText.ContainsKey(key))
		{
			result = localizedText [key];
		}
		return result;
	}

	public bool GetIsReady ()
	{
		return isReady;
	}

	public bool TransOk ()
	{
		return transOk;
	}

}





// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.IO;

// public class LocalizationManager : MonoBehaviour {

// 	public static LocalizationManager instance;
// 	private Dictionary<string, string> localizedText;
// 	private bool isReady = false;
// 	private string missingTextString = "Localized text not found";

// 	void Awake () 
// 	{
// 		if (instance == null)	
// 		{
// 			instance = this;
// 		}
// 		else if (instance != this)
// 		{
// 			Destroy (gameObject);
// 		}
// 		// DontDestroyOnLoad (gameObject);
// 	}	

// 	// public void LoadLocalizedText (string fileName) 
// 	// {
// 	// 	localizedText = new Dictionary<string, string> ();
// 	// 	string filePath = Path.Combine (Application.streamingAssetsPath, fileName);

// 	// 	if (File.Exists (filePath))
// 	// 	{
// 	// 		string dataAsJson = File.ReadAllText (filePath);
// 	// 		LocalizationData loadedData = JsonUtility.FromJson<LocalizationData> (dataAsJson);

// 	// 		for (int i = 0; i < loadedData.items.Length; i++) 
// 	// 		{
// 	// 			localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
// 	// 		}

// 	// 		Debug.Log ("Data loaded, dictionary contains: " + localizedText.Count + " entries");
// 	// 	}
// 	// 	else
// 	// 	{
// 	// 		Debug.LogError ("Cannot find file!!");
// 	// 	}

// 	// 	isReady = true;
// 	// }

// 	public void LoadLocalizedText (string fileName)
// 	{
// 		localizedText = new Dictionary<string, string> ();
// 		string filePath = Path.Combine (Application.streamingAssetsPath + "/", fileName);
// 		Debug.Log ("ABC" + filePath);

// 		if (File.Exists (filePath)) {
// 			string dataAsJson = File.ReadAllText (filePath);
// 			LocalizationData loadedData = JsonUtility.FromJson<LocalizationData> (dataAsJson);

// 			for (int i = 0; i < loadedData.items.Length; i++) {
// 				localizedText.Add (loadedData.items [i].key, loadedData.items [i].value);   
// 			}

// 			Debug.Log ("Data loaded, dictionary contains: " + localizedText.Count + " entries");
// 		} else {
// 			Debug.LogError ("Cannot find file! named" + fileName);
// 		}

// 		isReady = true;
// 	}

// 	IEnumerator LoadLocalizedTextOnAndroid (string fileName)
// 	{
// 		localizedText = new Dictionary<string, string> ();
// 		string filePath;// = Path.Combine(Application.streamingAssetsPath, fileName);
// 		filePath = Path.Combine (Application.streamingAssetsPath + "/", fileName);
// 		string dataAsJson;
// 		if (filePath.Contains ("://") || filePath.Contains (":///")) {
// 			//debugText.text += System.Environment.NewLine + filePath;
// 			Debug.Log ("UNITY:" + System.Environment.NewLine + filePath);
// 			UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get (filePath);
// 			yield return www.Send ();
// 			dataAsJson = www.downloadHandler.text;
// 		} else {
// 			dataAsJson = File.ReadAllText (filePath);
// 		}
// 		LocalizationData loadedData = JsonUtility.FromJson<LocalizationData> (dataAsJson);

// 		for (int i = 0; i < loadedData.items.Length; i++) {
// 			localizedText.Add (loadedData.items [i].key, loadedData.items [i].value);
// 			Debug.Log ("KEYS:" + loadedData.items [i].key);
// 		}

// 		isReady = true;
// 	}

// 	public void SetLanguage (string fileName)
// 	{
// 		if (Application.platform == RuntimePlatform.WindowsEditor)
// 			LoadLocalizedText (fileName);
// 		else if (Application.platform == RuntimePlatform.OSXEditor)
// 			LoadLocalizedText (fileName);
// 		else if (Application.platform == RuntimePlatform.Android)
// 			StartCoroutine ("LoadLocalizedTextOnAndroid", fileName);
// 	}

// 	public string GetLocalizedValue (string key) 
// 	{
// 		string result = missingTextString;

// 		if (localizedText.ContainsKey (key))
// 		{
// 			result = localizedText [key];
// 		}

// 		return result;
// 	}


// 	public bool GetIsReady ()
// 	{
// 		return isReady;
// 	}
// }