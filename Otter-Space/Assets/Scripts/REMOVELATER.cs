using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REMOVELATER : MonoBehaviour {

    public float Speed = 0f;
    public float rSpeed = 0f;
    private float movex = 0f;
    private float movey = 0f;
    public float gravity = 0f;
    bool Ongravity = false;

    private Vector3 otherpos;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("space"))
        {
            if (rSpeed < 0.6f)
            {
                rSpeed += 0.2f * Time.deltaTime;
            }
            transform.Rotate(0, 0, rSpeed);
        }
        else
        {
            rSpeed = 0;
        }

        if (movey > 0.0f)
        {
            if (Speed < 5.0f)
            {
                Speed += 0.8f * Time.deltaTime;
            }
        }
        movex = Input.GetAxis("Horizontal");
        movey = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(movex * Speed, movey * Speed);

        if (Ongravity)
        {
            if (gravity < 1.0f)
            {
                gravity += 0.4f * Time.deltaTime;
            }
            Vector2 direction = (otherpos - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * gravity;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Planet")
        {
            otherpos = coll.transform.position;
            Ongravity = true;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Planet")
        {
            Ongravity = false;
            gravity = 0;
        }
    }
}
