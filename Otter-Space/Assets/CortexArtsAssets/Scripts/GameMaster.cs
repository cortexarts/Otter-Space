using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;

    //cache
    private AudioManager audioManager;

    void Start()
    {
        //caching
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("No AudioManager found in the scene.");
        }
    }

    void Update()
    {
    }

}
