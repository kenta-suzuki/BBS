using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPanelController : MonoBehaviour
{
	public TopPanelView View;

	// Use this for initialization
	void Start()
	{
		View.ReloadButtonClicked += () => OnReloadButtonClick();
		View.ContentButtonClicked += (id) => OnThreadButtonClick(id);
		View.Initialize();
	}

	void OnReloadButtonClick()
	{
		DataManager.Manager.Models.BBSModel.RequestAllBBSData((datas) => ReloadCallback(datas));
	}

	void OnThreadButtonClick(long id)
	{
		// to thread page
	}

	void ReloadCallback(List<BBS> datas)
	{
		View.AddThread(datas);
	}

	void Show()
	{
		View.Show();
	}

	void Hide()
	{
		View.Hide();
	}
}
