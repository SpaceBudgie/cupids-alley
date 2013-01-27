using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour {

    public bool paused = false;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!paused)
            {
                Time.timeScale = 0.0f;
                paused = true;

                transform.FindChild("Background").gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 1.0f;
                paused = false;

                transform.FindChild("Background").gameObject.SetActive(false);
            }
        }
        
	}
}
