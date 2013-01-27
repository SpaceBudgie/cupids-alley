using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour 
{


    AnimatedSprite animation = null;

    public GameObject track = null;

	// Use this for initialization
	void Start () 
    {
	    animation = transform.FindChild("Plane").GetComponent<AnimatedSprite>();
	}
	
	// Update is called once per frame
	void Update () 
    {

        if(animation.startTheGame || Input.GetKeyDown(KeyCode.Return))
        {
            GameObject.Find("StateChange").GetComponent<StateChange>().SetGameState();
            track.SetActive(true);
        }

	}
}
