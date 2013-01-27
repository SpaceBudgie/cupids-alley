using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour 
{

    public Texture shootingTexture;
    public Texture drivingTexture;

    PlayerModel player = null;

	// Use this for initialization
	void Start () 
    {
	
        player = GameObject.Find("Player").GetComponent<PlayerModel>();

	}
	
	// Update is called once per frame
	void Update () 
    {
        if(player.IsShooting())
        {
            renderer.material.SetTexture("_MainTex", shootingTexture);
        }
        else
        {
            renderer.material.SetTexture("_MainTex", drivingTexture);
        }

	}
}
