using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public float fuelAmount;
    public Transform loadingBar;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainLevel" && fuelAmount == 100)
        {
            PlayerPrefs.SetFloat("fuelAmount", fuelAmount);
        }
        else
        {
            fuelAmount = PlayerPrefs.GetFloat("fuelAmount");
        }
    }

    // Update is called once per frame
    void Update()
    {
        loadingBar.GetComponent<Image>().fillAmount = fuelAmount / 100;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("fuelAmount", fuelAmount);
    }
}
