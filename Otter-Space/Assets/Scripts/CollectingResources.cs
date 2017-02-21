using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingResources : MonoBehaviour {
    public List<GameObject> Trees;
    public List<GameObject> Metal;

    // Use this for initialization
    void Start () {
       //PlayerPrefs.SetInt("woodAmount", 0);
       //PlayerPrefs.SetInt("metalAmount", 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Rocket").GetComponent<FloatingPlayer2DController>().refueling)
        {
            for (int i = 0; i < Trees.Count; i++)
            {
                Trees[i].SetActive(false);
                Trees.RemoveAt(i);
                PlayerPrefs.SetInt("woodAmount", GameObject.Find("WoodText").GetComponent<Wood>().woodAmount + 1);
            }
            for (int i = 0; i < Metal.Count; i++)
            {
                Metal[i].SetActive(false);
                Metal.RemoveAt(i);
                PlayerPrefs.SetInt("metalAmount", GameObject.Find("MetalText").GetComponent<Metal>().metalAmount + 1);
            }
        }
	}
}
