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
        metalAmount = PlayerPrefs.GetFloat("metalAmount");
    }

    // Update is called once per frame
    void Update()
    {
        loadingBar.GetComponent<Image>().fillAmount = metalAmount / 100;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("metalAmount", metalAmount);
    }
}
