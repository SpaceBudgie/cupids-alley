using UnityEngine;
using System.Collections;

public class PlayerModel : MonoBehaviour {

	public enum CharacterState {
		isDrivingSeat,
		isShootingSeat,	
	};


	public enum CarState {
		onPavement,
		onRoad,
	}

    float maxAcceleration = 30.0f;
    float minAcceleration = -30.0f;
    float accelerationOnRoad = 8.0f;
    float accelerationOnPavement = -5.0f;

    float decelerationOnRoad = 5.0f; 
    float decelerationOnPavement = 7.5f;

    float minSpeed = 30.0f;
	float maxSpeed = 100.0f;

    float currentAcceleration = 20.0f;
    float currentSpeed = 0.0f;

    float veerDirection = 0.0f;

    float initialY = 0.0f;

    Vector3 scale = new Vector3(0.15f, 0.15f, 1.5f);

	private CharacterState 	charState 		= CharacterState.isDrivingSeat;
	private CarState 		carState  		= CarState.onRoad;

    GunController gunController = null;

    Transform characterSprite = null;

    Vector3 drivingPosition = Vector3.zero;
    Vector3 shootingPosition = Vector3.zero;

	// Use this for initialization
	void Start()
	{
        Random.seed = 34234;

        gunController = transform.FindChild("Gun").GetComponent<GunController>();

        characterSprite = transform.FindChild("Sprite");

        drivingPosition = new Vector3(0.75f, 0.85f, 0.7685489f);
        shootingPosition = new Vector3(-1.05f, 1.8f, -0.01f);

        characterSprite.position = drivingPosition + transform.position;

        initialY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update()
    {
        Vector3 position = transform.position;

        if(position.x <= -5.75f || position.x >= 5.75f)
        {
            NowOnPavement();
            position.y = initialY + Random.Range(-0.1f, 0.1f);
        }
        else
        {
            NowOnRoad();
            position.y = initialY;
        }

        float acceleration = 0.0f;

        if(carState == CarState.onRoad)
        {
            acceleration = accelerationOnRoad;
        }
        else
        {
            acceleration = accelerationOnPavement;
        }

        if(IsShooting())
        {
            gunController.fire();

            if(OnRoad())
            {
                acceleration = -decelerationOnRoad;
            }
            else
            {
                acceleration = -decelerationOnPavement;
            }

            position.x += veerDirection * 3.0f * Time.deltaTime;
            position.x = Mathf.Clamp(position.x, -10.0f + transform.localScale.x / 2, 10.0f - transform.localScale.x / 2);
        }

        if(Time.timeScale != 0)
        {
            currentAcceleration += acceleration * 0.02f;
            clampAcceleration(acceleration);

            currentSpeed += currentAcceleration * 0.02f;
            clampSpeed();
        }

        position.z += currentSpeed * Time.deltaTime;
        position.z = Mathf.SmoothStep(transform.position.z, position.z, Time.time);

        transform.position = position;
    }

    void clampSpeed()
    {
        if (currentSpeed <= minSpeed - 0.5f) 
        {
            currentSpeed = minSpeed + 1.0f;
        }

        if (currentSpeed >= maxSpeed + 0.5f) 
        {
            currentSpeed = maxSpeed - 1.0f;
        }
    }

    void clampAcceleration(float a)
    {
        if (a > 0) 
        {
            if (currentAcceleration < 0) 
            {
                currentAcceleration = 0.0f;
            }
            else if (currentAcceleration > maxAcceleration + 1.0f) 
            {
                currentAcceleration = maxAcceleration;
            }
        }
        else 
        {
            if (currentAcceleration > 0) 
            {
                currentAcceleration = 0.0f;
            }
            else if (currentAcceleration < minAcceleration - 1.0f) 
            {
                currentAcceleration = minAcceleration;
            }
        }
    }

    public void HitObject()
    {
        currentSpeed -= 10.0f;
        clampSpeed();
    }

    public void TurnLeft()
    {
        Vector3 position = transform.position;
        position.x -= 15.0f * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, -10.0f + transform.localScale.x / 2, 10.0f - transform.localScale.x / 2);

        transform.position = position;
    }

    public void TurnRight()
    {
        Vector3 position = transform.position;
        position.x += 15.0f * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, -10.0f + transform.localScale.x / 2, 10.0f - transform.localScale.x / 2);

        transform.position = position;
    }

    public void SwitchToDriving() 
    { 
        charState = CharacterState.isDrivingSeat; 
        characterSprite.position = drivingPosition + transform.position;

        currentAcceleration = 0.0f;

        veerDirection = 0.0f;
    }

    public void SwitchToShooting() 
    { 
        charState = CharacterState.isShootingSeat; 
        characterSprite.position = shootingPosition + transform.position;

        currentAcceleration = 0.0f;

        veerDirection = (float)Random.Range(0, 2);
        veerDirection -= 0.5f;
        veerDirection *= 2.0f;  
    }

    public void NowOnRoad() { carState = CarState.onRoad; }
    public void NowOnPavement() { carState = CarState.onPavement; }

	public bool OnRoad() 		{ return carState == CarState.onRoad; }
	public bool OnPavement() 	{ return carState == CarState.onPavement; }

	public bool IsDriving() 	{ return charState == CharacterState.isDrivingSeat; }
	public bool IsShooting()	{ return charState == CharacterState.isShootingSeat; }


}
