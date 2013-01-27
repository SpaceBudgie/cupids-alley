using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour 
{
    public int size = 128;

    public PlayerModel player = null;

    Camera uiCamera = null;

    

    Texture crosshairTexture;

	// Use this for initialization
	void Start () 
    {
        uiCamera = GameObject.Find("UICamera").camera;

        crosshairTexture = renderer.material.GetTexture("_MainTex");

        Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void OnGUI() 
    {
        if(player.IsShooting())
        {
            GUI.DrawTexture(new Rect(Input.mousePosition.x - size / 2, (Screen.height - Input.mousePosition.y) - size / 2, size, size), crosshairTexture);
        }
	}
}
