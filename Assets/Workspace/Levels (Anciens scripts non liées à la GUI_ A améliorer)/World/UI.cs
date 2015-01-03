using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    [SerializeField]
    private Text LifesText;

    [SerializeField]
    private Text ScoreText;

    [SerializeField]
    private Text TimeText;

    void Update()
    {
	    // Texte
        if (LifesText) LifesText.text = "Vies: "  + GlobalVariables.Instance.Lifes;
        if (ScoreText) ScoreText.text = "Score: " + GlobalVariables.Instance.LevelScore;
        if (TimeText) TimeText.text   = "Temps: " + Mathf.Floor( GlobalVariables.Instance.currentTime).ToString();
    }
}
