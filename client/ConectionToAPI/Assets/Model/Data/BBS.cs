using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class BBS : BaseData
{
	public string Subject;
	public string Text;
	public string Email;
	public string Password;
	public string FileName;
	public long ParentBbsId;
	public bool IsDeleted;
	public string CreatedAt;
	public Texture2D Image;

	public static BBS CreateData(JSONObject jsonObj)
	{
		Debug.Log(jsonObj);
		var bbs = new BBS();
		bbs.Id = jsonObj.GetField("id").i;
		bbs.Subject = ConvertString(jsonObj.GetField("subject").str);
		bbs.Text = ConvertString(jsonObj.GetField("text").str);
		bbs.Email = jsonObj.GetField("email").str;
		bbs.Password = jsonObj.GetField("password").str;
		bbs.FileName = jsonObj.GetField("file_name").str;
		bbs.ParentBbsId = long.Parse(jsonObj.GetField("parent_bbs_id").str);
		bbs.IsDeleted = jsonObj.GetField("is_deleted").b;
		bbs.CreatedAt = jsonObj.GetField("created_at").str;
		if (jsonObj.HasField("image"))
		{
			bbs.Image = ConvertToTexture(jsonObj.GetField("image").str);
			bbs.Image.name = bbs.FileName;
		}

		return bbs;
	}

	public JSONObject GetJsonData()
	{
		var json = new JSONObject();
		json.AddField("id", Id);
		json.AddField("subject", Subject);
		json.AddField("text", Text);
		json.AddField("email", Email);
		json.AddField("password", Password);
		json.AddField("file_name", FileName);
		json.AddField("parent_bbs_id", ParentBbsId);
		json.AddField("is_deleted", IsDeleted);

		return json;
	}

	static string ConvertString(string str)
	{
		return System.Text.RegularExpressions.Regex.Unescape(str);
	}

	static Texture2D  ConvertToTexture(string byteString)
	{
		var texture = new Texture2D(0,0);
		texture.LoadImage(ConvertToByte(byteString));
		return texture;
	}

	static byte[] ConvertToByte(string byteString)
	{
		try
		{
			byteString = ConvertString(byteString);
			var value = Convert.FromBase64String(byteString);
			return value;
		}
		catch (OverflowException)
		{
			throw new OverflowException(byteString + " not convert");
		}
	}

	public Sprite ConvertImageToSprite()
	{
		return Sprite.Create(Image, new Rect(0, 0, 200, 200), new Vector2(0.5f, 0.5f));
	}
}
