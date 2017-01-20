using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using System.Linq;

public class APIConnection : MonoBehaviour
{
	static APIConnection _apiConnection;
	public static APIConnection Conncetion { get { return _apiConnection; } }
	bool _canSendRequest;

	void Start()
	{
		_apiConnection = this;
		_canSendRequest = true;
	}

	public void Request(Request request, Action<List<JSONObject>> callback = null)
	{
		StartCoroutine(Send(request, callback));
	}

	UnityWebRequest CreateRequest(Request request)
	{
		if (request.Method == HTTPMethod.Get)
		{
			return UnityWebRequest.Get(request.URI);
		}
		else
		{
			return UnityWebRequest.Post(request.URI, request.GetPostDataFromParameter());
		}
	}

	void OnReciveResponse(string response, Action<List<JSONObject>> callback)
	{
		Debug.Log(response);
		if (callback == null) return;

		var jsonObj = new JSONObject(response);
		Debug.Log(jsonObj);
		if (response[0] == '{')
		{
			var list = new List<JSONObject>() { jsonObj };
			callback(list);
		}
		else
		{
			callback(jsonObj.list);
		}
	}

	IEnumerator Send(Request request, Action<List<JSONObject>> callback)
	{
		if (!_canSendRequest) yield break;

		_canSendRequest = false;

		Debug.Log("URI : " + request.URI + ", Method : " + request.Method);
		using (UnityWebRequest www = CreateRequest(request))
		{
			yield return www.Send();

			_canSendRequest = true;
			if (www.isError || www.responseCode != 200)
			{
				var message = www.isError ? www.error : www.responseCode.ToString() + www.downloadHandler.text;
				Debug.LogError(string.Format("Fail Whale!\n{0}", message));
				yield break;
			}
			else
			{
				OnReciveResponse(www.downloadHandler.text, callback);
			}
		}
	}
}
