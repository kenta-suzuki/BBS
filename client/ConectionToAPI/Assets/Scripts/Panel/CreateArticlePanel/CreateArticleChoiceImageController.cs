using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CreateArticleChoiceImageController : ControllerBase<CreateArticleChoiceImageController, CreateArticleChoiceImageView>
{
	CreateArticleModel _model;
	List<Texture2D> _textures = new List<Texture2D>();

	public event Action<Texture2D> ImageChose = delegate {	};

	protected override void Initialize()
	{
		base.Initialize();
		View.SubmitButtonClicked += () => OnArticleImageSubmitButtonClick();
		View.SelectImageClicked += (id) => OnArticleImageClick(id);
	}

	protected override void OnPageHide()
	{
		Clear();
		_model.ImageLoaded -= CreateContent;
	}

	public void SetModel(CreateArticleModel model)
	{
		_model = model;
		_model.ImageLoaded += CreateContent;
		_model.LoadImages();
	}

	void CreateContent(List<Texture2D> textures)
	{
		View.CreateContents(textures);
	}

	void OnArticleImageSubmitButtonClick()
	{
		if (View.GetSelectContent() == null) return;

		var selectImage = View.GetSelectContent().SelectImage;
		_model.SetImage(selectImage);
		ImageChose(selectImage);
		ImageChose = delegate {};
		Hide();
	}

	void OnArticleImageClick(int id)
	{
		View.ChangeCheckMark(id);
	}
}
