using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TopPanelView : MonoBehaviour
{
	[SerializeField]
	GameObject Panel;
	[SerializeField]
	CommonButton ReloadButton;
	[SerializeField]
	GameObject Grid;

	public event Action ReloadButtonClicked;
	public event Action<long> ContentButtonClicked = delegate {};
	List<ThreadContent> _contents = new List<ThreadContent>();

	public void Initialize()
	{
		ClearThreadDatas();
		ReloadButton.ButtonClicked += () => ReloadButtonClicked();
	}

	public void AddThread(List<BBS> datas)
	{
		datas.ForEach((obj) => CreateContent(obj));
	}

	public void CreateContent(BBS data)
	{
		var content = ThreadContent.Create(Grid.transform);
		content.ThreadButtonClicked += () => ContentButtonClicked(data.Id);
		content.Initialize(data);
		_contents.Add(content);
	}

	public void ClearThreadDatas()
	{
		_contents.ForEach((obj) => Destroy(obj.gameObject));
		_contents.Clear();
	}

	public void Show()
	{
		Panel.SetActive(true);
	}

	public void Hide()
	{
		Panel.SetActive(false);
	}
}
