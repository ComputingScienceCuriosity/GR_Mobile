using UnityEngine;
using System.Collections;

public class World : MonoBehaviour
{
    public void Update()
    {
        if(!GlobalVariables.Instance.isPaused)
        { 
            if (GlobalVariables.Instance.currentTime > 1)
            {
                GlobalVariables.Instance.currentTime -= Time.deltaTime;
            }else
                Application.LoadLevel("MainMenu");
        }
    }

    public void AddCoin()
    {
        GlobalVariables.Instance.LevelScore += 10;
    }
}