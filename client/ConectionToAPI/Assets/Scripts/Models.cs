using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Models
{
	public BBSModel BBSModel;

	public void Initialize()
	{
		BBSModel = new BBSModel();
		BBSModel.Initialize();
	}
}
