using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubesLeftUI : MonoBehaviour
{
	public TMP_Text cubesLeftTxt;

	private void Update()
	{
		cubesLeftTxt.text = "Cubes : " + GameManager.Instance.lm.nbCubesToSpawn;
	}
}
