using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
	static DataManager _manager;
	public static DataManager Manager
	{
		get
		{
			return _manager;
		}
	}

	public Models Models;
	// Use this for initialization
	void Start () 
	{
		_manager = this;
		Models = new Models();
		Models.Initialize();
	}
}
