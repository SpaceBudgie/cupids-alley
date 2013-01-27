using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{

    PlayerModel model = null;

    UIScript gui = null;

    // Use this for initialization
    void Start() 
    {
        model = transform.GetComponent<PlayerModel>();

        gui = GameObject.Find("GUIObj").GetComponent<UIScript>();  
    }

    // Update is called once per frame
    void Update() 
    {
        if(gui.paused == false) 
        {
            if(model.IsDriving()) 
            {
                if (Input.GetKey(KeyCode.A)) 
                {
                    model.TurnLeft();
                }

                if (Input.GetKey(KeyCode.D)) 
                {
                    model.TurnRight();
                }

                if (Input.GetKeyDown(KeyCode.Space)) 
                {
                    model.SwitchToShooting();
                }
            }
            else 
            {
                if (Input.GetKeyDown(KeyCode.Space)) 
                {
                    model.SwitchToDriving();
                }
            }
        }
    }

}
