using UnityEngine;
using System.Collections;

public class StateChange : MonoBehaviour {

	public GameObject gameState 	= null;
    public GameObject startState    = null;
	public GameObject introState 	= null;
	public GameObject gameOverState = null;
	public GameObject winState 		= null;

	// Use this for initialization
	void Start ()
	{
		gameState.SetActive(false);
        startState.SetActive(true);
		introState.SetActive(false);
		gameOverState.SetActive(false);
        winState.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
			
	}


	public void SetGameState()
	{
        gameState.SetActive(true);
        startState.SetActive(false);
		introState.SetActive(false);
		gameOverState.SetActive(false);
		winState.SetActive(false);
	}

    public void SetStartState()
    {
        gameState.SetActive(false);
        startState.SetActive(true);
        introState.SetActive(false);
        gameOverState.SetActive(false);
        winState.SetActive(false);
    }

	
	public void SetIntroState()
	{
		gameState.SetActive(false);
        startState.SetActive(false);
        introState.SetActive(true);
		gameOverState.SetActive(false);
		winState.SetActive(false);
	}


	public void SetGameOverState()
	{
		gameState.SetActive(false);
        startState.SetActive(false);
		introState.SetActive(false);
        gameOverState.SetActive(true);
		winState.SetActive(false);
	}


	public void SetWinState()
	{
		gameState.SetActive(false);
        startState.SetActive(false);
		introState.SetActive(false);
		gameOverState.SetActive(false);
        winState.SetActive(true);
	}
}
