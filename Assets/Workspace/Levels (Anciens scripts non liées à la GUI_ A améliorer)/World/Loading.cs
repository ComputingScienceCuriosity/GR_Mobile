using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {

    void Awake()
    {
        Application.LoadLevel("MainMenu");
    }
}
