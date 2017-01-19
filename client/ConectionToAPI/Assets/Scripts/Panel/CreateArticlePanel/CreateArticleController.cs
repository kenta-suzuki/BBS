using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CreateArticleController : ControllerBase<CreateArticleController, CreateArticleView>
{
	CreateArticleModel _createArticleModel;

	protected override void Initialize()
	{
		base.Initialize();
		_createArticleModel = new CreateArticleModel();

		View.CreateArticleButtonClicked += () => OnCreateArticleButtonClick();
		View.AddFileButtonClicked += () => OnAddFileButtonClick();

		View.EmailInputFieldCompleted += (email) => OnEmailInput(email);
		View.NameInputFieldCompleted += (name) => OnNameInput(name);
		View.TextInputFieldCompleted += (text) => OnTextInput(text);
	}

	void OnCreateArticleButtonClick()
	{
		DataManager.Manager.Models.BBSModel.CreateArticle(_createArticleModel.GetJsonData());
	}

	void OnAddFileButtonClick()
	{
		CreateArticleChoiceImageController.Open(PageManager.Instance.transform, () => Show(), "Prefabs/ChoiceFileDialog");
	}

	void OnNameInput(string subject)
	{
		_createArticleModel.Subject = subject;
	}

	void OnTextInput(string text)
	{
		_createArticleModel.Text = text;
	}

	void OnEmailInput(string email)
	{
		_createArticleModel.Email = email;
	}
}
