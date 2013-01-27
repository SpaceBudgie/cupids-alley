using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

    public Transform bulletPrefab;

    public float rateOfFire = 1.0f;

    public float bulletSpeed = 1.0f;

    float timer = 0.0f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    public void fire() {
        timer -= rateOfFire * Time.deltaTime;

        if (Input.GetButton("Shoot") && timer <= 0) {
            Vector3 position = transform.position;
            position.x -= 1.05f;
            position.z += 5.0f;

            Transform bullet = Instantiate(bulletPrefab, position, Quaternion.identity) as Transform;


            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100.0f));

            Vector3 target = ray.direction;
            target.x += Random.Range(-0.1f, 0.1f);
            target.y += Random.Range(-0.1f, 0.1f);
            target.z += Random.Range(-0.1f, 0.1f);


            Vector3 velocity = target * bulletSpeed;

            Quaternion rot = Quaternion.identity;//  = transform.rotation;




            rot.SetFromToRotation(Vector3.forward, target);

            bullet.transform.rotation = rot;


            bullet.parent = transform;
            bullet.name = "Bullet";

            velocity.x *= 1.5f;
            velocity.y = (velocity.y * 1.5f) + 50.0f;
            velocity.z += transform.parent.rigidbody.velocity.z;

            bullet.rigidbody.AddForce(velocity, ForceMode.Force);

            Destroy(bullet.gameObject, 2.0f);

            timer = 1.0f;
        }

    }
}