using UnityEngine;
using System.Collections;

public class Boomer : MonoBehaviour 
{
    void OnTriggerEnter(Collider other)
    {
        GlobalVariables.Instance.LevelScore = GlobalVariables.Instance.Score;
        GlobalVariables.Instance.Lifes--;

        if (GlobalVariables.Instance.Lifes == 0)
		    Application.LoadLevel("GameOver");
	    else
		    Application.LoadLevel(Application.loadedLevelName);
    }
}
