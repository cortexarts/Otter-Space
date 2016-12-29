using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public float currentAmount;
    public Transform loadingBar;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
        loadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
    }
}
