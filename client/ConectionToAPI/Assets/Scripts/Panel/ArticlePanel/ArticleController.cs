using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ArticleController : ControllerBase<ArticleController, ArticleView>
{
	ArticleModel _model;
	protected override void Initialize()
	{
		base.Initialize();
		View.ReloadButtonClicked += () => OnReloadButtonClick();
		View.DeleteButtonClicked += () => OnDeleteButtonclick();
		View.ResponseButtonClicked += () => OnResponseButtonClick();
		View.DeleteCheckButtonClicked += (id) => OnCheckDeleteButtonClick(id);
	}

	public void SetBBSData(long id)
	{
		Clear();

		_model = new ArticleModel(id);
		View.SetParentBBS(_model.ParentArticle);
		View.CreateResponses(_model.ResponseArtilces);
	}

	void OnReloadButtonClick()
	{
		DataManager.Manager.Models.BBSModel.RequestAllBBSData(ReloadCallback);
	}

	void ReloadCallback(List<BBS> datas)
	{
		var responseDatas = datas.Where(data => data.Id != _model.ParentArticle.Id && data.ParentBbsId == _model.ParentArticle.Id).ToList();
		_model.AddResponse(responseDatas);
		View.CreateResponses(_model.NewResponsArticles);
	}

	void OnCheckDeleteButtonClick(long id)
	{
		View.SetDeleteCheckMark(id);
		if (_model.HasDeleteArticle(id))
		{
			_model.RemoveDeleteAritcles(id);
			return;
		}

		_model.AddDeleteArticles(id);
	}

	void OnDeleteButtonclick()
	{
		DataManager.Manager.Models.BBSModel.DeleteArticles(_model.GetDeleteArticlesJson(), DeleteCallback);
	}

	void DeleteCallback()
	{
		View.DeleteResponse(_model.DeleteArticles);
		_model.ClearDeleteArticles();
	}

	void OnResponseButtonClick()
	{
		var controller = ResponseController.Open(PageManager.Instance.transform, () => Show(), "Prefabs/Pages/CreateResponsePanel");
		controller.ResponseCallback += () =>
		{
			Show();
			OnReloadButtonClick();
		};
		controller.SetParentArticleId(_model.ParentArticle.Id);
		Hide();
	}
}
