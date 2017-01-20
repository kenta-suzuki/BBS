using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChoiceImageContent : MonoBehaviour 
{
	[SerializeField]
	Image Image;
	[SerializeField]
	Image CheckMark;
	[SerializeField]
	CommonButton SelectButton;

	Texture2D _texture;
	public Texture2D SelectImage { get { return _texture; } }
	public bool IsSelected { get { return CheckMark.gameObject.activeSelf; } }
	public int Id { get; private set;}
	public event Action SelectButtonClicked;

	public void Initialize(Texture2D texture, int id)
	{
		_texture = texture;
		TextureScale.Bilinear(texture, 200, 200);
		Image.sprite = Sprite.Create(texture, new Rect(0, 0, 200, 200), new Vector2(0.5f, 0.5f));
		Id = id;
		CheckMark.gameObject.SetActive(false);
		SelectButton.ButtonClicked += () => SelectButtonClicked();
	}

	public void SetCheckMark(int id)
	{
		CheckMark.gameObject.SetActive(Id == id && !IsSelected);
	}

	public static ChoiceImageContent Create(Transform parent, Texture2D texture, int id)
	{
		var obj = (GameObject)Instantiate(Resources.Load("Prefabs/UploadImage"), parent);
		var content = obj.GetComponent<ChoiceImageContent>();
		content.Initialize(texture, id);
		return content;
	}
}
