using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class CreateArticleChoiceImageView : ViewBase
{
	[SerializeField]
	GameObject Grid;
	[SerializeField]
	CommonButton SubmitButton;

	public event Action SubmitButtonClicked;
	public event Action<int> SelectImageClicked;
	
	List<ChoiceImageContent> _contents = new List<ChoiceImageContent>();

	public override void Initialize()
	{
		base.Initialize();
		SubmitButton.ButtonClicked += () => SubmitButtonClicked();
	}

	public void CreateContents(List<Texture2D> textures)
	{
		textures.ForEach((img) => CreateContent(img, _contents.Count));
	}

	void CreateContent(Texture2D texture, int id)
	{
		var content = ChoiceImageContent.Create(Grid.transform, texture, id);
		content.SelectButtonClicked += () => SelectImageClicked(id);
		_contents.Add(content);
	}

	public void ChangeCheckMark(int id)
	{
		_contents.ForEach((obj) => obj.SetCheckMark(id));
	}

	public ChoiceImageContent GetSelectContent()
	{
		return _contents.FirstOrDefault(content => content.IsSelected);
	}
}
