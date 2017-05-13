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
        woodAmount = PlayerPrefs.GetFloat("woodAmount");
    }

    // Update is called once per frame
    void Update()
    {
        loadingBar.GetComponent<Image>().fillAmount = woodAmount / 100;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("woodAmount", woodAmount);
    }
}
