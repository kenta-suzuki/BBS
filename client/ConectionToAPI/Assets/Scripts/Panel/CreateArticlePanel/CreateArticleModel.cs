using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateArticleModel
{
	public string Subject { get; set; }
	public string Text { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
	public string FileName { get; set; }
	public byte[] ImageBinary { get; private set;}

	public JSONObject GetJsonData()
	{
		var json = new JSONObject();
		json.AddField("subject", Subject);
		json.AddField("text", Text);
		json.AddField("email", Email);
		json.AddField("password", Password);
		json.AddField("file_name", FileName);

		return json;
	}

	public void SetImage(Texture2D texutre)
	{
		ImageBinary = texutre.EncodeToJPG();
	}
}
