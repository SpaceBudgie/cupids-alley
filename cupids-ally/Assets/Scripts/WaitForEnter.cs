using UnityEngine;
using System.Collections;

public class WaitForEnter : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            
            GameObject.Find("StateChange").GetComponent<StateChange>().SetIntroState();
        }
	}
}
