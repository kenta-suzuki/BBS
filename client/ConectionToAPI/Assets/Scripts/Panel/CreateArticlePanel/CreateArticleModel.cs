using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CreateArticleModel
{
	public string Subject { get; set; }
	string _text;
	public string Text 
	{
		get
		{
			if (string.IsNullOrEmpty(_text))
			{
				_text = "本文やで！";
			}
			return _text;
		}
		set
		{
			_text = value;
		}
	}
	public string Email { get; set; }
	public string Password { get; set; }
	public string FileName { get; set; }
	public Texture2D ArticleImage { get; set; }

	public event Action<List<Texture2D>> ImageLoaded = delegate {};

	public JSONObject GetJsonData()
	{
		var json = new JSONObject();
		json.AddField("subject", Subject);
		json.AddField("text", Text);
		json.AddField("email", Email);
		json.AddField("password", Password);
		json.AddField("file_name", FileName);

		Debug.Log(json.ToString());
		return json;
	}

	public void SetImage(Texture2D texture)
	{
		ArticleImage = texture;
		FileName = texture.name;
	}

	public void LoadImages()
	{
		List<Texture2D> textures  = new List<Texture2D>();
		var filePath = GetImageFolderPath();
		Debug.Log("Load Folder : " + filePath);
		DirectoryInfo dir = new DirectoryInfo(filePath);
		FileInfo[] info = dir.GetFiles("*.jpg");

		foreach (var file in info)
		{
			Texture2D tex = new Texture2D(0, 0);
			tex.LoadImage(LoadBin(filePath + "/" + file.Name));
			tex.name = file.Name;
			textures.Add(tex);
		}
		ImageLoaded(textures);
	}

	byte[] LoadBin(string path)
	{
		FileStream fs = new FileStream(path, FileMode.Open);
		BinaryReader br = new BinaryReader(fs);
		byte[] buf = br.ReadBytes((int)br.BaseStream.Length);
		br.Close();
		return buf;
	}

	string GetImageFolderPath()
	{
		#if UNITY_EDITOR
		return GetPCFolderPath();
		#elif UNITY_IPHONE
		return GetIOSFolderPath();
		#endif
	}

	string GetPCFolderPath()
	{
		return UserTerminalInfo.GetMyDocumentPath() + "/Desktop/study/bbs/pictures";;
	}

	string GetIOSFolderPath()
	{
		return Application.dataPath + "/images";
	}

	string GetAndroidFolderPath()
	{
		return Application.dataPath + "/images";
	}
}
