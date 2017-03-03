using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Metal : MonoBehaviour
{
    public float metalAmount;
    public Transform loadingBar;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainLevel")
        {
            PlayerPrefs.SetFloat("metalAmount", metalAmount);
        }
        else if (SceneManager.GetActiveScene().name == "Landing")
        {
            metalAmount = PlayerPrefs.GetFloat("metalAmount");
        }
    }

    // Update is called once per frame
    void Update()
    {
        loadingBar.GetComponent<Image>().fillAmount = metalAmount / 100;
    }
}
