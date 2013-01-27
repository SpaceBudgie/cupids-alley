using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnvironmentGenerator : MonoBehaviour {

    public Transform player;

    public Transform streetPrefab;

    public int numberOfSections = 0;

    public Texture[] peopleSprites;

    Transform[] streetSections;

    float sectionExtents;
    Vector3 lastSectionPosition = Vector3.zero;


	// Use this for initialization
	void Start () 
    {
        streetSections = new Transform[numberOfSections];

        sectionExtents = streetPrefab.localScale.z;

        for(int i = 0; i < numberOfSections; i++)
        {
            Vector3 position = Vector3.zero;
            position.y = streetPrefab.localScale.y / 2;
            position.z += sectionExtents * i;

            streetSections[i] = Instantiate(streetPrefab, position, Quaternion.identity) as Transform;
            streetSections[i].GetComponent<StreetSection>().environment = this;
            streetSections[i].name = "Street";
            streetSections[i].parent = transform;
        }

        lastSectionPosition = streetSections[numberOfSections - 1].position;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void MoveSection(Transform section)
    {
        Vector3 position = lastSectionPosition;
        position.z += sectionExtents;

        section.position = position;
        lastSectionPosition = position;

        section.gameObject.SendMessage("Reset", null);
    }
}
