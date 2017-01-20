using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CreateArticleView : ViewBase
{
	[SerializeField]
	InputField NameInputField;
	[SerializeField]
	InputField EmailInputField;
	[SerializeField]
	InputField TextInputField;
	[SerializeField]
	InputField PasswordInputField;
	[SerializeField]
	Image ArticleImage;
	[SerializeField]
	CommonButton AddFileButton;
	[SerializeField]
	CommonButton CreateArticleButton;

	public event Action AddFileButtonClicked;
	public event Action CreateArticleButtonClicked;

	public event Action<string> NameInputFieldCompleted;
	public event Action<string> EmailInputFieldCompleted;
	public event Action<string> TextInputFieldCompleted;
	public event Action<string> PasswordInputFieldCompleted;

	public override void Initialize()
	{
		base.Initialize();
		AddFileButton.ButtonClicked += () => AddFileButtonClicked();
		CreateArticleButton.ButtonClicked += () => CreateArticleButtonClicked();

		NameInputField.onValueChanged.AddListener((name) => NameInputFieldCompleted(name));
		EmailInputField.onValueChanged.AddListener((email) => EmailInputFieldCompleted(email));
		TextInputField.onValueChanged.AddListener((text) => TextInputFieldCompleted(text));
		PasswordInputField.onValueChanged.AddListener((pass) => PasswordInputFieldCompleted(pass));
	}

	public void SetArticleImage(Texture2D texture)
	{
		TextureScale.Bilinear(texture, 200, 200);
		ArticleImage.sprite = Sprite.Create(texture, new Rect(0, 0, 200, 200), new Vector2(0.5f, 0.5f));
	}

	public override void Clear()
	{
		NameInputField.text = "";
		EmailInputField.text = "";
		TextInputField.text = "";
		PasswordInputField.text = "";
		ArticleImage.sprite = null;
	}
}
