using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravidade : MonoBehaviour {

    public PlanetScript planeta;
    private Transform playerTransform;

    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        playerTransform = transform;
    }

    void FixedUpdate()
    {
        if (planeta)
        {
            planeta.Attract(playerTransform);
        }
    }
}
