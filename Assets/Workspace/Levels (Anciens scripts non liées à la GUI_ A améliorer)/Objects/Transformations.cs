using UnityEngine;
using System.Collections;
using System;

public class Transformations : MonoBehaviour {

    [SerializeField]
    private int TranslationSpeed = 1;
    [SerializeField]
    private int RotationSpeed    = 1;
	
	// Update is called once per frame
	void Update () 
    {
	    var n = 0;

	    // Translations
	    var objects = GameObject.FindGameObjectsWithTag("Translating");
	    foreach (var obj in objects)
        {
            Vector3 transf = new Vector3(obj.transform.position.x, obj.transform.position.y, Mathf.Sin((Time.timeSinceLevelLoad + n++) * TranslationSpeed) * 2);
		    obj.transform.position = transf;
    	}

	    // Rotations
	    objects = GameObject.FindGameObjectsWithTag("Rotating");
	    foreach (var obj in objects)
        {
         
            Quaternion rotation = Quaternion.identity;
            float tempY = obj.transform.rotation.eulerAngles.y + (RotationSpeed / 4.0f);
            rotation.eulerAngles = new Vector3 (obj.transform.rotation.eulerAngles.x, tempY, obj.transform.rotation.eulerAngles.z);
            obj.transform.rotation = rotation;
		}

	    // Crazy blocks
        if (!Application.loadedLevelName.Equals("Level1") && !Application.loadedLevelName.Equals("Level5")) // sert à éviter le bug de la version 4.6 avec les tags inéxistants
        { 
            objects = GameObject.FindGameObjectsWithTag("CrazyBlock");
            foreach (var obj in objects)
            {
                float tempY = Mathf.Sin((Time.timeSinceLevelLoad + n++) * TranslationSpeed * 4) * 0.3f;
                Vector3 transY = new Vector3(obj.transform.localPosition.x, tempY, obj.transform.localPosition.z);

		        obj.transform.localPosition = transY;
	        }
        }

	    // Coins
	    objects = GameObject.FindGameObjectsWithTag("Coin");
        foreach (var obj in objects)
        {
            Quaternion rotation = Quaternion.identity;

            float tempY = (Time.timeSinceLevelLoad + n++) * 80 * RotationSpeed;
            rotation.eulerAngles = new Vector3(obj.transform.rotation.eulerAngles.x, tempY, obj.transform.rotation.eulerAngles.z);
            obj.transform.rotation = rotation;
        }
		
	    // PushingPlatform
	    objects = GameObject.FindGameObjectsWithTag("Pushing");
	    foreach (var obj in objects)
	    {
            Vector3 scaleZ = new Vector3(obj.transform.localScale.x, obj.transform.localScale.y, (2.5f + Mathf.Sin((Time.timeSinceLevelLoad + n++) * TranslationSpeed) * 1.5f));
		    obj.transform.localScale = scaleZ;
            Vector3 transZ = new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y, (2.5f - obj.transform.localScale.z / 2));
		    obj.transform.localPosition = transZ;
	    }
	
	    // Touche cheat
	    if (Input.GetKey(KeyCode.LeftAlt))
	    {
            GlobalVariables.Instance.Score = GlobalVariables.Instance.LevelScore;
            GlobalVariables.Instance.currentTime = 100.0f;
            GlobalVariables.Instance.Lifes = 9;
	
		    int levelIndex =  Convert.ToInt16(Application.loadedLevelName.Substring(5));
		
		    if (levelIndex == 5)
			    Application.LoadLevel("End");
		    else
			    Application.LoadLevel("Level" + (levelIndex + 1));
	    }
	}
}
