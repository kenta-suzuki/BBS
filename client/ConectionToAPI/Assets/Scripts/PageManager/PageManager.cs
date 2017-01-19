using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
	static PageManager _instance;
	public static PageManager Instance { get { return _instance; } }

	Dictionary<string, GameObject> _pages = new Dictionary<string, GameObject>();
	public Dictionary<string, GameObject> Pages { get {return _pages; } }

	void Start()
	{
		_instance = GetComponent<PageManager>();
		TopPanelController.Open(transform, null, "Prefabs/Pages/TopPanel");
	}

	public void Add(string name, GameObject obj)
	{
		_pages.Add(name, obj);
	}

	public void Remove(string name)
	{
		Destroy(_pages[name]);
		_pages.Remove(name);
	}
}
