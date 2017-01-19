using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateArticleChoiceImageController : ControllerBase<CreateArticleChoiceImageController, CreateArticleChoiceImageView>
{
	CreateArticleModel _model;
	List<Texture2D> _textures = new List<Texture2D>();

	protected override void Initialize()
	{
		base.Initialize();
		View.SubmitButtonClicked += () => OnSelectButtonClick();
		View.SelectImageClicked += (id) => OnChoiceImageClick(id);
		LoadImages();
	}

	public void SetModel(CreateArticleModel model)
	{
		_model = model;
	}

	void LoadImages()
	{
		Debug.Log("Load Folder : " + Application.dataPath);
		DirectoryInfo dir = new DirectoryInfo(Application.dataPath);
		FileInfo[] info = dir.GetFiles("*.jpg");

		foreach (var file in info)
		{
			Texture2D tex = new Texture2D(0, 0);
			tex.LoadImage(LoadBin(Application.dataPath + "/" + file.Name));
			_textures.Add(tex);
		}
		View.CreateContents(_textures);
	}

	byte[] LoadBin(string path)
	{
		FileStream fs = new FileStream(path, FileMode.Open);
		BinaryReader br = new BinaryReader(fs);
		byte[] buf = br.ReadBytes((int)br.BaseStream.Length);
		br.Close();
		return buf;
	}

	void OnSelectButtonClick()
	{
		_model.SetImage(View.GetSelectContent().SelectImage);
	}

	void OnChoiceImageClick(int id)
	{
		View.ChangeCheckMark(id);
	}
}
