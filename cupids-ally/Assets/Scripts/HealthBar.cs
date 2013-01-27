using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour 
{

    public RabbitController rabbit;
    
    float initialScale = 0.0f;
    float initialHealth = 0.0f;

	// Use this for initialization
	void Start() 
    {
        initialScale = transform.localScale.x;
        initialHealth = rabbit.health;
	}
	
	// Update is called once per frame
	void Update() 
    {
        Vector3 scale = transform.localScale;
        scale.x = (rabbit.health / initialHealth) * initialScale;

        transform.localScale = scale;

        if(rabbit.health <= 0)
        {
            Destroy(gameObject);
        }
	}
}
