using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGlowEnter : MonoBehaviour {

    private bool collided = false;
    private bool leaving = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (collided)
        {
            Camera.main.orthographicSize += 8.0f * Time.deltaTime;

            if (Camera.main.orthographicSize > 49)
            {
                collided = false;
            }
        }

        if (leaving)
        {
            Camera.main.orthographicSize -= 8.0f * Time.deltaTime;

            if (Camera.main.orthographicSize < 14)
            {
                leaving = false;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Planet")
        {
            collided = true;
        }
     }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Planet")
        {
            leaving = true;
        }
    }
}
