using UnityEngine;
using System.Collections;

public class Stop_Jongler : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
	    if (other.gameObject.CompareTag ("Player")) {
		    Destroy(gameObject);
	}
}
}
