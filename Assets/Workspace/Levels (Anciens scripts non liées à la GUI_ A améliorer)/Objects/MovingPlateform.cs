using UnityEngine;
using System.Collections;

public class MovingPlateform : MonoBehaviour {

    [SerializeField]
	public float Start  = 1;

    [SerializeField]
    public float End    = 2;

    [SerializeField]
    public float Speed  = 1;

    [SerializeField]
    public float Shift  = 0;

    void Update()
    {
        float   moveX  =  Mathf.Sin((Time.timeSinceLevelLoad + Start + Shift) * Speed) * (End - Start) / 2 + (End + Start) / 2;
        Vector3 temp = new Vector3(moveX, transform.position.y, transform.position.z);

        transform.position = temp;
    }
}
