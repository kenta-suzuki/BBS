using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ArticleModel
{
	public BBS ParentArticle { get; private set;}
	public List<BBS> ResponseArtilces { get; private set;}
	public List<BBS> NewResponsArticles { get; private set;}
	public List<BBS> DeleteArticles { get; private set;}

	public ArticleModel(long id)
	{
		DeleteArticles = new List<BBS>();
		var model = DataManager.Manager.Models.BBSModel;
		ParentArticle = model.ArticleBBSDatas.First(data => data.Id == id);
		ResponseArtilces = model.ResponsBBSDatas.Where(data => data.ParentBbsId == id).ToList();
	}

	public void AddResponse(List<BBS> allResponses)
	{
		var latestId = ResponseArtilces.LastOrDefault() != null
									   ? ResponseArtilces.LastOrDefault().Id
									   : ParentArticle.Id;
		
		NewResponsArticles = allResponses.Where(res => res.Id > latestId).ToList();
		ResponseArtilces.AddRange(NewResponsArticles);
	}

	public bool HasDeleteArticle(long id)
	{
		return DeleteArticles.FirstOrDefault(data => data.Id == id) != null;
	}

	public void AddDeleteArticles(long id)
	{
		var article = DataManager.Manager.Models.BBSModel.BBSDatas.First(data => data.Id == id);
		DeleteArticles.Add(article);
	}

	public void RemoveDeleteAritcles(long id)
	{
		var article = DataManager.Manager.Models.BBSModel.BBSDatas.First(data => data.Id == id);
		DeleteArticles.Remove(article);
	}

	public void ClearDeleteArticles()
	{
		DeleteArticles.Clear();
	}

	public List<JSONObject> GetDeleteArticlesJson()
	{
		return DeleteArticles.Select(data => data.GetJsonData()).ToList();
	}
}
