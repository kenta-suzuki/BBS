using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ResponsePlate : MonoBehaviour
{
	const string PrefabName = "Prefabs/ResponsePlate";

	[SerializeField]
	Text Name;
	[SerializeField]
	Text CreatedAt;
	[SerializeField]
	Text ResponseText;
	[SerializeField]
	Image CheckMark;
	[SerializeField]
	CommonButton DeleteCheckButton;

	public long Id { get; private set; }
	public bool IsSelected { get { return CheckMark.gameObject.activeSelf; } }
	public event Action<long> DeleteCheckButtonClicked;

	public static ResponsePlate Create(Transform parent)
	{
		var plate = (GameObject)Instantiate(Resources.Load(PrefabName), parent);
		return plate.GetComponent<ResponsePlate>();
	}

	public void Initialize(BBS bbs)
	{
		CreatedAt.text = bbs.CreatedAt;
		ResponseText.text = bbs.Text;
		Id = bbs.Id;
		DeleteCheckButton.ButtonClicked += () => DeleteCheckButtonClicked(Id);
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
}
