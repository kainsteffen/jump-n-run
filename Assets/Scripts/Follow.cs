using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject target;
    public Vector2 offSet;
    public bool followX;
    public bool followY;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (followX)
        {
            transform.position = new Vector3(target.transform.position.x + offSet.x, transform.position.y, transform.position.z);
        }

        if (followY)
        {
            transform.position = new Vector3(transform.position.x, target.transform.position.y + offSet.y, transform.position.z);
        }
    }
}
