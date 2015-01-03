using UnityEngine;
using System.Collections;
using System;

public class Portal : MonoBehaviour {

	 
    void OnTriggerEnter(Collider other)
    {
        Canvas canvasLoading = GameObject.FindGameObjectWithTag("loading").GetComponent<Canvas>() as Canvas;

        GlobalVariables.Instance.Score = GlobalVariables.Instance.LevelScore;
        GlobalVariables.Instance.currentTime = 100.0f;

	    int levelIndex = 	Convert.ToInt16(Application.loadedLevelName.Substring(5));

        if (levelIndex == 5)
            Application.LoadLevel("End");
        else
        {
            canvasLoading.enabled  = true;
            Application.LoadLevel("Level" + (levelIndex + 1));
            
        }
    }
}
