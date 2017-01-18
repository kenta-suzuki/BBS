using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CommonButton : MonoBehaviour
{
	Button button;
	public event Action ButtonClicked = delegate {};

	void Start ()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(() => OnClick());
	}

	void OnClick()
	{
		ButtonClicked();
	}
}
