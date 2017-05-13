using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingResources : MonoBehaviour {
    public List<GameObject> Trees;
    public List<GameObject> Metal;

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Rocket").GetComponent<FloatingPlayer2DController>().refueling)
        {
            for (int i = 0; i < Trees.Count; i++)
            {
                Trees[i].SetActive(false);
                Trees.RemoveAt(i);
                PlayerPrefs.SetFloat("woodAmount", GameObject.Find("WoodCont").GetComponent<Wood>().woodAmount + 1.0f);
                GameObject.Find("WoodCont").GetComponent<Wood>().woodAmount += 1.0f;
            }
            for (int i = 0; i < Metal.Count; i++)
            {
                Metal[i].SetActive(false);
                Metal.RemoveAt(i);
                PlayerPrefs.SetFloat("metalAmount", GameObject.Find("MetalCont").GetComponent<Metal>().metalAmount + 1.0f);
                GameObject.Find("MetalCont").GetComponent<Metal>().metalAmount += 1.0f;
            }
        }
	}
}
