using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
	public event Action<long> DeleteCheckButtonClicked;

	List<ResponsePlate> _responsePlates = new List<ResponsePlate>();

	public override void Initialize()
	{
		base.Initialize();
		ReloadButton.ButtonClicked += () => ReloadButtonClicked();
		DeleteButton.ButtonClicked += () => DeleteButtonClicked();
		ResponseButton.ButtonClicked += () => ResponseButtonClicked();
		ArticleParent.DeleteCheckButtonClicked += (id) => DeleteCheckButtonClicked(id);
	}

	public void SetParentBBS(BBS bbs)
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
		plate.DeleteCheckButtonClicked += (id) => DeleteCheckButtonClicked(id);
		plate.Initialize(response);
		_responsePlates.Add(plate);
	}

	public void DeleteResponse(List<BBS> deleteResponse)
	{
		deleteResponse.ForEach(res => DeletePlate(res));
	}

	void DeletePlate(BBS data)
	{
		var plate = _responsePlates.First(p => p.Id == data.Id);
		Destroy(plate.gameObject);
		_responsePlates.Remove(plate);
	}

	public override void Clear()
	{
		ArticleParent.Clear();
		_responsePlates.ForEach(res => Destroy(res.gameObject));
		_responsePlates.Clear();
	}

	public void SetDeleteCheckMark(long id)
	{
		ArticleParent.SetCheckMark(id);
		_responsePlates.ForEach(article => article.SetCheckMark(id));
	}
}
