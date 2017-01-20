using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UserTerminalInfo
{
	public static List<string> GetUserDeviceInfos()
	{
		var infos = new List<string>();
		infos.Add(SystemInfo.deviceName);
		infos.Add(SystemInfo.graphicsDeviceName);
		infos.Add(SystemInfo.deviceUniqueIdentifier);
		return infos;
	}

	public static string GetPicturePath()
	{
		return Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
	}

	public static string GetMyDocumentPath()
	{
		return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
	}
}
