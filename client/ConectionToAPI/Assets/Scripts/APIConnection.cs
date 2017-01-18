using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class APIConnection : MonoBehaviour
{
	static APIConnection _apiConnection;
	public static APIConnection Conncetion { get { return _apiConnection; } }
	const string URL = "http://192.168.33.19:8000/bbs/";
	WWW www;
	List<JSONObject> _list;

	void Start()
	{
		_apiConnection = this;
	}

	public void Request(Action<List<JSONObject>> callback)
	{
		StartCoroutine(WaitForResponse(callback));
	}

	IEnumerator WaitForResponse(Action<List<JSONObject>> callback)
	{
		_list = null;
		var requestURL = URL;
		www = new WWW(requestURL);

		yield return www;

		if (!string.IsNullOrEmpty(www.error))
		{
			Debug.LogError(string.Format("Fail Whale!\n{0}", www.error));
			yield break;
		}

		string json = www.text;
		JSONObject jsonObj = new JSONObject(json);
		callback(jsonObj.list);
	}
}
