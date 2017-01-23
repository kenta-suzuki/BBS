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
		View.IsResponse = false;
		View.CreateArticleButtonClicked += () => OnCreateArticleButtonClick();
		View.AddFileButtonClicked += () => OnArticleImageChoiceButtonClick();

		View.EmailInputFieldCompleted += (email) => OnEmailInput(email);
		View.NameInputFieldCompleted += (name) => OnNameInput(name);
		View.TextInputFieldCompleted += (text) => OnTextInput(text);
		View.PasswordInputFieldCompleted += (pass) => OnPasswordInput(pass);
	}

	protected override void OnPageShow()
	{
		_createArticleModel = new CreateArticleModel();
	}

	protected override void OnPageHide()
	{
		Clear();
	}

	void OnCreateArticleButtonClick()
	{
		DataManager.Manager.Models.BBSModel.CreateArticle(_createArticleModel, () => Clear());
	}

	void OnArticleImageChoiceButtonClick()
	{
		var choiceController = CreateArticleChoiceImageController.Open(PageManager.Instance.transform, () => Show(), "Prefabs/ChoiceFileDialog");
		choiceController.SetModel(_createArticleModel);
		choiceController.ImageChose += OnArticleImageChoose;
	}

	void OnArticleImageChoose(Texture2D texture)
	{
		View.SetArticleImage(texture);
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

	void OnPasswordInput(string pass)
	{
		_createArticleModel.Password = pass;
	}
}
