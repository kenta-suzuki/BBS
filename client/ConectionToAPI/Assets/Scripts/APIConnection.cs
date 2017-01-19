using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class APIConnection : MonoBehaviour
{
	static APIConnection _apiConnection;
	public static APIConnection Conncetion { get { return _apiConnection; } }
	const string URL = "http://192.168.33.19:8000/";
	string _requestURL;
	WWW _www;
	List<JSONObject> _list;

	void Start()
	{
		_apiConnection = this;
	}

	public void Request(string host, string parameter,  Action<List<JSONObject>> callback = null)
	{
		_requestURL = URL + host + "/" + parameter;
		StartCoroutine(WaitForResponse(callback));
	}

	IEnumerator WaitForResponse(Action<List<JSONObject>> callback)
	{
		_list = null;
		_www = new WWW(_requestURL);
		Debug.Log(_requestURL);

		yield return _www;

		if (!string.IsNullOrEmpty(_www.error))
		{
			Debug.LogError(string.Format("Fail Whale!\n{0}", _www.error));
			yield break;
		}

		string json = _www.text;
		JSONObject jsonObj = new JSONObject(json);
		if(callback != null) callback(jsonObj.list);
	}
}
