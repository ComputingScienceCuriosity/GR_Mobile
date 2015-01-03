using UnityEngine;
using System.Collections;

public class GunRespawn : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
    {
	    var objects = GameObject.FindGameObjectsWithTag("Gun") as GameObject[];
	    foreach (var obj in objects)
	    {
            //(obj.GetComponent(typeof(Gun)) as Gun).enabled = true;
            Gun properties          = obj.GetComponent<Gun>();
		    properties.NextSpawn    = Time.timeSinceLevelLoad;
	    } 
    }
}
