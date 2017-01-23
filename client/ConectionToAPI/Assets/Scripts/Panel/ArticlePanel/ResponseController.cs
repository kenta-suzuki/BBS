using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResponseController : ControllerBase<ResponseController, CreateArticleView>
{
	CreateArticleModel _createArticleModel;

	public event Action ResponseCallback;

	protected override void Initialize()
	{
		base.Initialize();
		View.IsResponse = true;
		View.CreateArticleButtonClicked += () => OnCreateResponseButtonClick();

		View.EmailInputFieldCompleted += (email) => OnEmailInput(email);
		View.TextInputFieldCompleted += (text) => OnTextInput(text);
		View.PasswordInputFieldCompleted += (pass) => OnPasswordInput(pass);
	}

	protected override void OnPageShow()
	{
		View.ShowResponseType();
	}

	public void SetParentArticleId(long id)
	{
		_createArticleModel = new CreateArticleModel();
		_createArticleModel.ParentId = id;
	}

	protected override void OnPageHide()
	{
		Clear();
		ResponseCallback = delegate {};
	}

	void OnCreateResponseButtonClick()
	{
		DataManager.Manager.Models.BBSModel.CreateArticle(_createArticleModel, () =>
		{
			ResponseCallback();
			Hide();
		});

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
