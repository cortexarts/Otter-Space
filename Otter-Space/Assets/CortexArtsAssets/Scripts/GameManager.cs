using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    private AudioManager audioManager;

    void Start()
    {
        // Creating a copy of the audio manager
        audioManager = AudioManager.instance;

        if (audioManager == null)
        {
            Debug.LogError(this.name + ": No AudioManager found!");
        }
    }

    void Update()
    {

    }

}
