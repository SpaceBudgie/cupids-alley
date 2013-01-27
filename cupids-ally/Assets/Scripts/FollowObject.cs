using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {

    public Transform item;

    public Vector3 displacement = Vector3.zero;

    float initialY = 0.0f;

	// Use this for initialization
	void Start () 
    {
        initialY = transform.position.y;
	}
	
	// Update is called once per frame
	void LateUpdate() 
    {
        Vector3 position = item.position - displacement;
        position.y = initialY;
        transform.position = position;
	}
}
