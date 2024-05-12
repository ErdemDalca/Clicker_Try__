using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentChn : MonoBehaviour
{
	public Button[] buttons;

	void Start()
	{
		buttons = GetComponentsInChildren<Button>();

		foreach (Button button in buttons)
		{
			button.onClick.AddListener(delegate { ButtonClicked(button.gameObject.name); });
		}
	}

	void ButtonClicked(string buttonName)
	{
		// Buton týklanma iþlemleri burada yapýlýr
		Debug.Log("Týklanan Buton: " + buttonName);
	}
}
