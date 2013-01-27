using UnityEngine;
using System.Collections;

public class CounterScript : MonoBehaviour
{
	public int counter = 0;

	public GUIStyle style;

	public Texture2D icon;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void AddCount() {
		counter += 1;
	}

    void OnGUI() {
        GUI.Label(new Rect(80, Screen.height - 60, 100, 20), counter.ToString(), style);


        GUI.DrawTexture(new Rect(20,Screen.height - 60,60,60), icon);
    }
}
