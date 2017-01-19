using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ControllerBase<T,V> : MonoBehaviour where V :ViewBase, new() where T : ControllerBase<T,V>
{
	protected V View;
	public virtual string PrefabName { get; }
	public event Action BackButtonClicked = delegate {};

	public static void Open(Transform parent, Action backbuttonClickCallback, string prefabName)
	{
		if (!PageManager.Instance.Pages.ContainsKey(prefabName))
		{
			var obj = (GameObject)Instantiate(Resources.Load(prefabName), parent);
			var controller = obj.GetComponent<T>();
			controller.BackButtonClicked += () => backbuttonClickCallback();
			controller.Initialize();
			PageManager.Instance.Add(prefabName, obj);
		}
		else
		{
			var controller = PageManager.Instance.Pages[prefabName].GetComponent<T>();
			controller.Show();
		}
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

	protected void Hide()
	{
		View.Hide();
	}

	protected void Show()
	{
		View.Show();
	}
}
