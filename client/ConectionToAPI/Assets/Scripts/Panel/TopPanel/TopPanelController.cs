using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
		var controller = ArticleController.Open(PageManager.Instance.transform, () =>
		{
			Show();
			OnReloadButtonClick();
		},
		"Prefabs/Pages/ArticlePanel");
		controller.SetBBSData(id);
		Hide();
	}

	void OnCreateArticleButtonClick()
	{
		Hide();
		CreateArticleController.Open(PageManager.Instance.transform, () => Show(), "Prefabs/Pages/CreateArticlePanel");
	}

	void ReloadCallback(List<BBS> datas)
	{
		var parents = datas.Where(data => data.Id == data.ParentBbsId).ToList();
		View.AddThread(parents);
	}
}
