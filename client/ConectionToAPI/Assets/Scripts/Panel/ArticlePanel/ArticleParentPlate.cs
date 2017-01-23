using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ArticleParentPlate : MonoBehaviour
{
	[SerializeField]
	Text Title;
	[SerializeField]
	Text Text;
	[SerializeField]
	Image CheckMark;
	[SerializeField]
	CommonButton DeleteCheckButton;
	[SerializeField]
	Image ArticleImage;

	public long Id { get; private set; }
	public bool IsSelected { get { return CheckMark.gameObject.activeSelf; } }
	public event Action<long> DeleteCheckButtonClicked;

	void Start()
	{
		DeleteCheckButton.ButtonClicked += () => DeleteCheckButtonClicked(Id);
	}

	public void Initialize(BBS bbs)
	{
		Title.text = bbs.Subject;
		Text.text = bbs.Text;
		Id = bbs.Id;
		ArticleImage.sprite = bbs.ConvertImageToSprite();
	}

	public void SetCheckMark(long id)
	{
		if (IsSelected && id != Id) return;
		if (IsSelected && id == Id)
		{
			CheckMark.gameObject.SetActive(false);
			return;
		}

		CheckMark.gameObject.SetActive(Id == id);
	}

	public void Clear()
	{
		Title.text = "";
		Text.text = "";
		Id = -1;
		CheckMark.gameObject.SetActive(false);
	}
}
