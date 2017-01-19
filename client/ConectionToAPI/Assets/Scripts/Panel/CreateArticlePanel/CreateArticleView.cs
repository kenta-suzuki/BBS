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
	CommonButton AddFileButton;
	[SerializeField]
	CommonButton CreateArticleButton;

	public event Action AddFileButtonClicked;
	public event Action CreateArticleButtonClicked;

	public event Action<string> NameInputFieldCompleted;
	public event Action<string> EmailInputFieldCompleted;
	public event Action<string> TextInputFieldCompleted;

	public override void Initialize()
	{
		base.Initialize();
		AddFileButton.ButtonClicked += () => AddFileButtonClicked();
		CreateArticleButton.ButtonClicked += () => CreateArticleButtonClicked();

		NameInputField.onEndEdit.AddListener((name) => NameInputFieldCompleted(name));
		EmailInputField.onEndEdit.AddListener((email) => NameInputFieldCompleted(email));
		TextInputField.onEndEdit.AddListener((text) => NameInputFieldCompleted(text));
	}
}
