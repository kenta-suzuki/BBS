using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		bbs.ParentBbsId = jsonObj.GetField("parent_bbs_id").i;
		bbs.IsDeleted = jsonObj.GetField("is_deleted").b;
		bbs.CreatedAt = jsonObj.GetField("created_at").str;

		return bbs;
	}

	static string ConvertString(string str)
	{
		return System.Text.RegularExpressions.Regex.Unescape(str);
	}
}
