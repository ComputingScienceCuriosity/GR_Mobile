using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    [SerializeField]
    private Text ScoreText;

	// Use this for initialization
	void Start () 
    {
        if (ScoreText) ScoreText.text = "Votre score : " + GlobalVariables.Instance.Score;
	}

    public void Go()
    {
        Application.LoadLevel("MainMenu");
    }
}
