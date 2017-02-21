using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Metal : MonoBehaviour {

    public Text txt;
    public int metalAmount;

    // Use this for initialization
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = metalAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = metalAmount.ToString();
        metalAmount = PlayerPrefs.GetInt("metalAmount");
        PlayerPrefs.SetInt("metalAmount", metalAmount);
    }
}
