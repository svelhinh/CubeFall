using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	private GameManager gm;

	private void Awake()
	{
		gm = GameManager.Instance;
	}

	public void Play()
	{
		gm.LoadScene("Level");
	}
}
