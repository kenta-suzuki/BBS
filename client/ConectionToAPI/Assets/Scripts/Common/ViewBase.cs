using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ViewBase : MonoBehaviour 
{
	[SerializeField]
	GameObject RootPanel;
	[SerializeField]
	CommonButton BackButton;

	public event Action BackButtonClicked;

	public virtual void Initialize()
	{
		BackButton.ButtonClicked += () => BackButtonClicked();
	}

	public void Show()
	{
		RootPanel.SetActive(true);
	}

	public void Hide()
	{
		RootPanel.SetActive(false);
	}
}
