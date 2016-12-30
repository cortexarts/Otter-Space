using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour {

    public GameObject Earth;
    public GameObject Launch;

    public string weaponShootSound = "RocketEngine";
    // Caching

    AudioManager audioManager;
    // Use this for initialization
    void Start()
    {
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("FREAK OUT! No audiomanager found in scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            audioManager.PlaySound("RocketEngine");
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            audioManager.StopSound("RocketEngine");
            Earth.SetActive(true);
            Launch.SetActive(false);
        }
    }
}
