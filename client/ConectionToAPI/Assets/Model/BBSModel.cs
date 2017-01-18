using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BBSModel :BaseModel
{
	public List<BBS> BBSDatas { get; private set;}
	bool _canSendRequest;

	public override void Initialize()
	{
		BBSDatas = new List<BBS>();
		_canSendRequest = true;
	}

	public void AddData(List<JSONObject> objects)
	{
		objects.ForEach((obj) => BBSDatas.Add(BBS.CreateData(obj)));
	}

	public void RequestAllBBSData(Action<List<BBS>> callback)
	{
		if (!_canSendRequest) return;

		_canSendRequest = false;
		APIConnection.Conncetion.Request((objects) =>
		{
			AddData(objects);
			callback(BBSDatas);
			_canSendRequest = true;
		});
	}
}
