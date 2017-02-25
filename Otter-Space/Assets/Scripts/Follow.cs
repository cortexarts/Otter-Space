using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    public GameObject player;       //Public variable to store a reference to the player game object
    private Vector3 trackpos;

    // Use this for initialization
    void Start()
    {
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        trackpos = new Vector3(player.transform.position.x, player.transform.position.y + 15.5f, gameObject.transform.position.z);
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        gameObject.transform.localPosition = trackpos;
    }
}
