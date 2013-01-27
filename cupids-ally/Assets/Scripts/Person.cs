using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour {

    //public GameObject spritePrefab;

    public CounterScript counter;

    // Use this for initialization
    void Start() {

        //GameObject sprite = Instantiate(spritePrefab, transform.position, transform.rotation) as GameObject;
        //transform.parent = sprite.transform;
        //sprite.transform.parent = transform;

        Quaternion rot = Quaternion.identity;
        rot.eulerAngles = new Vector3(90, -180, 0);
        transform.rotation = rot;

        Vector3 pos = transform.position;
        pos.y += (transform.localScale.y / 2);

        transform.position = pos;

        counter = GameObject.Find("GUIObj").GetComponent<CounterScript>();
    }

    // Update is called once per frame
    void Update() {

    }


    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Player" || other.gameObject.name == "Bullet") {
            Quaternion rot = Quaternion.identity;
            rot.eulerAngles = new Vector3(0, -180, 0);

            Quaternion curRot = transform.rotation;

            curRot = rot;

            transform.rotation = curRot;


            Vector3 pos = transform.position;
            pos.y -= 0.75f * 2.0f;

            transform.position = pos;

            counter.AddCount();

            GetComponent<BoxCollider>().isTrigger = false;

            if(other.gameObject.name == "Player")
            {   
                other.gameObject.GetComponent<PlayerModel>().HitObject();
            }

            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).GetComponent<AnimatedSprite>().play();
        }
    }
}
