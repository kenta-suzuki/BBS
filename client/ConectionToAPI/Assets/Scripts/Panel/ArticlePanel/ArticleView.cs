using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class ArticleView : ViewBase
{
	[SerializeField]
	ArticleParentPlate ArticleParent;
	[SerializeField]
	GameObject ScrollViewContent;
	[SerializeField]
	CommonButton ReloadButton;
	[SerializeField]
	CommonButton DeleteButton;
	[SerializeField]
	CommonButton ResponseButton;

	public event Action ReloadButtonClicked;
	public event Action DeleteButtonClicked;
	public event Action ResponseButtonClicked;

	List<ResponsePlate> _responsePlates = new List<ResponsePlate>();

	public override void Initialize()
	{
		base.Initialize();
		ReloadButton.ButtonClicked += () => ReloadButtonClicked();
		DeleteButton.ButtonClicked += () => DeleteButtonClicked();
		ResponseButton.ButtonClicked += () => ResponseButtonClicked();
	}

	public void CreateParent(BBS bbs)
	{
		ArticleParent.Initialize(bbs);
	}

	public void CreateResponses(List<BBS> responseDatas)
	{
		responseDatas.ForEach((data) => CreateResponsePlate(data));
	}

	public void CreateResponsePlate(BBS response)
	{
		var plate = ResponsePlate.Create(ScrollViewContent.transform);
		plate.Initialize(response);
		_responsePlates.Add(plate);
	}

	public override void Clear()
	{
		ArticleParent.Clear();
		_responsePlates.ForEach(res => Destroy(res.gameObject));
		_responsePlates.Clear();
	}
}
