using UnityEngine;
using System.Collections;

public class CharacterTrigger : MonoBehaviour 
{
    void OnTriggerEnter(Collider other)
    {
	    if (other.gameObject.tag == "Translatingu" || other.gameObject.tag == "Rotating")
		    transform.parent = other.transform;
    }

    void OnTriggerExit(Collider other)
    {
	    if (other.gameObject.tag == "Translatingu" || other.gameObject.tag == "Rotating")
		    transform.parent = null;
    }
}
