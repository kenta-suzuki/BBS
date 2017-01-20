using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Request 
{
	const string URL = "http://192.168.33.19:8000/";

	public string EndPoint { get; private set;}
	public HTTPMethod Method { get; private set;}
	public string Parameter { get; private set;}
	public Texture2D ArticleImage { get; private set;}
	public string URI { get { return URL + EndPoint; } }

	public Request(string endPoint, HTTPMethod method, string parameter = "", Texture2D articleImage = null)
	{
		EndPoint = endPoint;
		Method = method;
		Parameter = parameter;
		ArticleImage = articleImage;
	}

	public JSONObject GetJsonFromParameter()
	{
		return new JSONObject(Parameter);
	}

	public Dictionary<string, string> GetDictionaryFromParameter()
	{
		return GetJsonFromParameter().ToDictionary();
	}

	public WWWForm GetPostDataFromParameter()
	{
		var form = new WWWForm();

		foreach (var data in GetDictionaryFromParameter())
		{
			form.AddField(data.Key, data.Value);
		}

		if (ArticleImage != null)
		{
			SetArticleImage(form);
		}

		return form;
	}

	public void SetArticleImage(WWWForm form)
	{
		var name = ArticleImage.name;
		var data = ArticleImage.EncodeToJPG();
		form.AddBinaryData("image", data, name);
	}
}
