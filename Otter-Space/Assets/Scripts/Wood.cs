using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wood : MonoBehaviour
{
    public float woodAmount;
    public Transform loadingBar;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainLevel")
        {
            PlayerPrefs.SetFloat("woodAmount", woodAmount);
        }
        else if (SceneManager.GetActiveScene().name == "Landing")
        {
            woodAmount = PlayerPrefs.GetFloat("woodAmount");
        }
    }

    // Update is called once per frame
    void Update()
    {
        loadingBar.GetComponent<Image>().fillAmount = woodAmount / 100;
    }
}
