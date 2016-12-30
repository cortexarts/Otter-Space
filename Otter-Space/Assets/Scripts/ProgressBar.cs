using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    public GameObject resources;
    public float currentAmount;
    public Transform loadingBar;

    void Start()
    {
    }
	
	// Update is called once per frame
	void Update () {
        currentAmount = resources.GetComponent<GatherResources>().currentMetal;
        loadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
    }
}
