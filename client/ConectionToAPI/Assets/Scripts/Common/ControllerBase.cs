using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ControllerBase<T,V> : MonoBehaviour where V :ViewBase, new() where T : ControllerBase<T,V>
{
	protected V View;
	public virtual string Identifier { get; }
	public event Action BackButtonClicked = delegate {};

	public static T Open(Transform parent, Action backbuttonClickCallback, string prefabName)
	{
		T controller;
		if (!PageManager.Instance.Pages.ContainsKey(prefabName))
		{
			var obj = (GameObject)Instantiate(Resources.Load(prefabName), parent);
			controller = obj.AddComponent<T>();
			controller.BackButtonClicked += () => backbuttonClickCallback();
			controller.Initialize();
			PageManager.Instance.Add(prefabName, obj);
		}
		else
		{
			controller = PageManager.Instance.Pages[prefabName].GetComponent<T>();
			controller.Show();
		}
		return controller;
	}

	protected virtual void Initialize()
	{
		View = GetComponent<V>();
		View.BackButtonClicked += () => OnBackButtonClick();
		View.Initialize();
		Show();
	}

	protected void OnBackButtonClick()
	{
		Hide();
		BackButtonClicked();
	}

	protected virtual void OnPageHide()
	{
	}

	protected void Hide()
	{
		View.Hide();
		OnPageHide();
	}

	protected virtual void OnPageShow()
	{
	}

	protected void Show()
	{
		View.Show();
		OnPageShow();
	}

	protected void Clear()
	{
		View.Clear();
	}
}
