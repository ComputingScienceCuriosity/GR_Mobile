using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    [SerializeField]
    public float Delay     = 1;

    [SerializeField]
    public float NextSpawn = 0;

    [SerializeField]
    public float Limit     = 0;
      
    [SerializeField]
    public Transform Bullet;

    void Update()
    {
	    float time = Time.timeSinceLevelLoad;
	
	    if (time > NextSpawn)
	    {
   		    var clone = Instantiate(Bullet, transform.position + new Vector3(0.0f, 1.5f, 0.0f), Quaternion.identity) as Transform;
		    clone.gameObject.tag = "Bullet";
	
		    NextSpawn += Delay;
	    }
	
	    var objects = GameObject.FindGameObjectsWithTag("Bullet");
	    foreach (var obj in objects)
		    if (obj.transform.position.y > 0 && obj.transform.position.x < Limit)
                Destroy(obj);
    }   


}
