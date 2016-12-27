using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REMOVELATER : MonoBehaviour {

    public float Speed = 0f;
    private float movex = 0f;
    private float movey = 0f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movey > 0.0f)
        {
            if (Speed < 6)
            {
                Speed += 0.8f * Time.deltaTime;
            }
        }
        movex = Input.GetAxis("Horizontal");
        movey = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(movex * Speed, movey * Speed);
    }
}
