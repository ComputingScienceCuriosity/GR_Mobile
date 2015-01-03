using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    GameObject world = null;

    public void Start()
    {
        world = GameObject.Find("World");


    }

    public void OnTriggerEnter ( Collider other)
    {
        world.SendMessage("AddCoin");
        renderer.enabled = false;
        collider.enabled = false;

        if(audio)
        audio.Play();
    }

    public void AddCoin()
    {
        GlobalVariables.Instance.LevelScore += 10;
       
    }
}
