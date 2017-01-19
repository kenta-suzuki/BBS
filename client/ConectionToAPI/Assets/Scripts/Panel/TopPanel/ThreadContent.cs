using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ThreadContent : MonoBehaviour
{
	[SerializeField]
	Image ArticleImage;
	[SerializeField]
	Text ArticleSubject;
	[SerializeField]
	CommonButton ArticleButton;

	const string PrefabName = "Prefabs/Thread";
	public event Action ThreadButtonClicked = delegate {};

	public void Initialize(BBS data)
	{
		ArticleSubject.text = data.Subject;
		// 画像が添付できるようになったら処理をかく
	}

	public static ThreadContent Create(Transform parent)
	{
		var obj = (GameObject)Instantiate(Resources.Load(PrefabName), parent);
		obj.transform.localPosition = Vector3.zero;
		return obj.GetComponent<ThreadContent>();
	}
}
