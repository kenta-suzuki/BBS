using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArticleController : ControllerBase<ArticleController, ArticleView>
{
	protected override void Initialize()
	{
		base.Initialize();
		View.ReloadButtonClicked += () => OnReloadButtonClick();
		View.DeleteButtonClicked += () => OnDeleteButtonclick();
		View.ResponseButtonClicked += () => OnResponseButtonClick();
	}

	protected override void OnPageHide()
	{
		Clear();
	}

	public void SetBBSData(BBS parentData, List<BBS> bbsDatas)
	{
	}

	void UpdateBBSData(List<BBS> bbsDatas)
	{
	}

	void OnReloadButtonClick()
	{
	}

	void OnDeleteButtonclick()
	{
	}

	void OnResponseButtonClick()
	{
	}


}
