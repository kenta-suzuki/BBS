using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPanelController : ControllerBase<TopPanelController, TopPanelView>
{
	protected override void Initialize()
	{
		base.Initialize();
		View.ReloadButtonClicked += () => OnReloadButtonClick();
		View.ContentButtonClicked += (id) => OnThreadButtonClick(id);
		View.CreateArticleButtonClicked += () => OnCreateArticleButtonClick();
	}

	void OnReloadButtonClick()
	{
		DataManager.Manager.Models.BBSModel.RequestAllBBSData((datas) =>
		{
			Clear();
			ReloadCallback(datas);
		});
	}

	void OnThreadButtonClick(long id)
	{
		// to thread page
	}

	void OnCreateArticleButtonClick()
	{
		Hide();
		CreateArticleController.Open(PageManager.Instance.transform, () => Show(), "Prefabs/Pages/CreateArticlePanel");
	}

	void ReloadCallback(List<BBS> datas)
	{
		View.AddThread(datas);
	}
}
