using UnityEngine;
using System.Collections;

public class StreetSection : MonoBehaviour 
{

    public EnvironmentGenerator environment = null;

    public GameObject[] spawnPoints;

    public GameObject spritePrefab;

    private GameObject personInstance = null;

    GameObject[] models;

	// Use this for initialization
	void Start () 
    {
        models = new GameObject[3];

        models[0] = transform.FindChild("StreetSection0").gameObject;
        models[1] = transform.FindChild("StreetSection1").gameObject;
        models[2] = transform.FindChild("StreetSection2").gameObject;

	    Reset();
	}
	
	// Update is called once per frame
	void Update () 
    {
	   
	}

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "CameraCollider")
        {
            environment.MoveSection(transform);
        }
    }

    public void Reset()
    {
        if(personInstance != null) {
            Destroy(personInstance);
        }

        int index = Random.Range(0, spawnPoints.Length);

        Quaternion rot = Quaternion.identity;
        rot.eulerAngles = new Vector3(-90, 0, 0);

        personInstance = Instantiate(spritePrefab, spawnPoints[index].transform.position, rot) as GameObject;

        Vector3 pos = personInstance.transform.position;
        //pos.y = spawnPoints[index].transform.position.y + (spritePrefab.transform.localScale.y / 2);
        pos.y += 0.8f;

        int texture = Random.Range(0, environment.peopleSprites.Length);

        personInstance.renderer.material.SetTexture("_MainTex", environment.peopleSprites[texture]);

        personInstance.transform.position = pos;

        for(int i = 0; i < 3; i++)
        {
            models[i].SetActive(false);
        }

        int model = Random.Range(0, models.Length);

        models[model].SetActive(true);
    }
}
