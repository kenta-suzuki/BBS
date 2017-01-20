using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class BBSModel :BaseModel
{	
	public List<BBS> BBSDatas { get; private set;}

	public override void Initialize()
	{
		BBSDatas = new List<BBS>();
	}

	public void CreateBBSData(List<JSONObject> objects)
	{
		BBSDatas.Clear();
		objects.ForEach((obj) => BBSDatas.Add(BBS.CreateData(obj)));
	}

	public void RequestAllBBSData(Action<List<BBS>> callback)
	{
		var request = new Request("articles", HTTPMethod.Get);
		APIConnection.Conncetion.Request(request, (objects) =>
		{
			CreateBBSData(objects);
			callback(BBSDatas);
		});
	}

	public void CreateArticle(CreateArticleModel model, Action callback)
	{
		var request = new Request("articles/create", HTTPMethod.Post, model.GetJsonData().ToString(), model.ArticleImage);
		APIConnection.Conncetion.Request(request, (objects) =>
		{
			BBSDatas.Add(BBS.CreateData(objects.First()));
			callback();
		});
	}
}
