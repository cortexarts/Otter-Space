using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Wood : MonoBehaviour {

    public Text txt;
    public int woodAmount;

    // Use this for initialization
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = woodAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = woodAmount.ToString();
        woodAmount = PlayerPrefs.GetInt("woodAmount");
        PlayerPrefs.SetInt("woodAmount", woodAmount);
    }
}
