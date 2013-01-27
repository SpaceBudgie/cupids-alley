using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour 
{
	// Use this for initialization
	void Start() 
    {
	    Destroy(gameObject, 2.0f);
	}

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }    
	
}
