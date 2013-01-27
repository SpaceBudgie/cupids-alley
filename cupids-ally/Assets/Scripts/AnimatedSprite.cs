using UnityEngine;
using System.Collections;

public class AnimatedSprite : MonoBehaviour 
{

    public bool playOnStart = false;
    public bool loop = false;

    public float animationSpeed = 1.0f;

    public Texture[] frames;

    int numberOfFrames = 0;
    public int currentFrame = 0;

    float animationTimer = 1.0f;

    public bool startTheGame = false;

    public bool playing = false;

    public void play() { playing = true; }
    public void stop() { playing = false; }

	// Use this for initialization
	void Start () 
    {
        numberOfFrames = frames.Length;

        playing = playOnStart;

        renderer.material.SetTexture("_MainTex", frames[0]);
	}
	
	// Update is called once per frame
	void Update () 
    {
        
        if(playing)
        {
            animationTimer -= animationSpeed * Time.deltaTime;

            if(animationTimer <= 0.0f) 
            {
                currentFrame++;

                if(currentFrame > numberOfFrames - 1) 
                {
                    if(loop)
                    {
                        currentFrame = 0;
                    }
                    else
                    {
                        playing = false;
                        startTheGame = true;
                        return;
                    }
                }

                renderer.material.SetTexture("_MainTex", frames[currentFrame]);

                animationTimer = 1.0f;
            }


        }
	}
}
