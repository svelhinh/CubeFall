using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
	public TMP_Text scoreTxt;

    // Start is called before the first frame update
    private void Start()
    {
	    scoreTxt.text = "Score : " + GameManager.Instance.score;
    }

    public void Return()
    {
		GameManager.Instance.LoadScene("MainMenu");
    }
}
