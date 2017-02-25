using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    public GameObject player;       //Public variable to store a reference to the player game object

    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    private Vector3 trackpos;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetString("landingBool") == "false")
        {
            //Calculate and store the offset value by getting the distance between the player's position and camera's position.
            offset = transform.position - player.transform.position;
        }
        else
        {
            offset = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        trackpos = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, gameObject.transform.position.z);
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = trackpos;
    }
}
