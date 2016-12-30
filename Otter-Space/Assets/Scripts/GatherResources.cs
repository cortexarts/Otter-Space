using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherResources : MonoBehaviour {

    public float currentWood;
    public float currentFuel;

    public GameObject[] metal;
    public GameObject[] wood;

    public float currentMetal = 0;

    void Start() {
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            for (int i = 0; i < metal.Length; i++)
            {
                currentMetal += 10;
                metal[i].SetActive(false);
            }
            for (int i = 0; i < wood.Length; i++)
            {
                currentWood += 10;
                wood[i].SetActive(false);
            }
        }
    }
}
