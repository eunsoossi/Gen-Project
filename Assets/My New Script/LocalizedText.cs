using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LocalizedText : MonoBehaviour {

	public string key;
	public GameObject titleNoUi;


	void Start()
	{
		titleNoUi = GameObject.FindGameObjectWithTag("titleNoUi");

		if (this.gameObject == titleNoUi)
		{
			TextMeshPro text2 = GetComponent<TextMeshPro>();
			text2.text = LocalizationManager.instance.GetLocalizedValue2(key);
		}
		else
		{
			TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
			text.text = LocalizationManager.instance.GetLocalizedValue(key);
		}
		
	}
}
