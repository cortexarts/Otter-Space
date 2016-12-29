using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherResources : MonoBehaviour {

    public int currentMetalAmount;
    public GameObject[] resources;

    private int nrResources;

    void Start() {
        nrResources = resources.Length;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            for (int i = 0; i < nrResources; i++)
            {
                currentMetalAmount += 10;
                resources[i].SetActive(false);
            }

        }
    }
}
