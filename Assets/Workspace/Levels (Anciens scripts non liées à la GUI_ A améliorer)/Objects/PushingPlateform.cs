using UnityEngine;
using System.Collections;

public class PushingPlateform : MonoBehaviour {

	private float Start = 1;
    private float End   = 2;
    private float Speed = 1;

    void Update()
    {
        Vector3 temp = new Vector3(Mathf.Sin((Time.timeSinceLevelLoad + Start) * Speed) * (End - Start) / 2 + (End + Start) / 2,transform.position.y, transform.position.z);
        transform.position = temp;
    }
}
