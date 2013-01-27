using UnityEngine;
using System.Collections;

public class RabbitController : MonoBehaviour 
{
    public Transform player;

    public float health = 50.0f;

    public float minDistanceFromPlayer = 20.0f;
    public float maxDistanceFromPlayer = 200.0f;

    enum State
    {
        isRunning,
        isDead,
    }

    State state = State.isRunning;

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 position = transform.position;

        if(state == State.isRunning)
        {
            position.x = Mathf.Sin(Time.time) * (9.0f - transform.localScale.x / 2);

            if(health <= 0.0f)
            {
                Destroy(gameObject, 1.0f);
                state = State.isDead;

                GameObject.Find("StateChange").GetComponent<StateChange>().SetWinState();
            }
        }

        position.z += 60.0f * Time.deltaTime;

        float minDistance = player.position.z + minDistanceFromPlayer;
        float maxDistance = player.position.z + maxDistanceFromPlayer;

        position.z = Mathf.Clamp(position.z, minDistance, maxDistance);

        position.z = Mathf.SmoothStep(transform.position.z, position.z, Time.time);

        float distanceFromPlayer = position.z - player.position.z;

        if(distanceFromPlayer >= maxDistanceFromPlayer)
        {
            GameObject.Find("StateChange").GetComponent<StateChange>().SetGameOverState();
        }

        transform.position = position;     
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Bullet")
        {
            if(health > 0)
            {
                health -= 1.0f;
            }

            return;
        }
    }
}
