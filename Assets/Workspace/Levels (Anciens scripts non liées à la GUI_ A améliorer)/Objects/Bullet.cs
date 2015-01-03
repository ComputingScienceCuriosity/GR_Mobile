using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void Update()
    {
        Vector3 temp = new Vector3(gameObject.transform.position.x-0.2f, gameObject.transform.position.y, gameObject.transform.position.z);
        gameObject.transform.position = temp;
    }

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
