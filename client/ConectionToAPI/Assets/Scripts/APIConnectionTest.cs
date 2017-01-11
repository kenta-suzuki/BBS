using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIConnectionTest : MonoBehaviour
{
	const string URL = "http://192.168.33.19:8000/bbs/";
	WWW www;

	public void SendRequest()
	{
		
	}

	void Start()
	{
		StartCoroutine(WaitForResponse());
	}

	IEnumerator WaitForResponse()
	{
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

		foreach (var data in jsonObj.list)
		{
			Debug.Log(data.GetField("subject"));
		}
	}
}
