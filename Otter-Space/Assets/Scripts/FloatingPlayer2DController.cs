﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class FloatingPlayer2DController : MonoBehaviour
{
    public float moveForce = 0;
    public float maxMoveForce = 10;
    public float rotationDamping = 0.01f;
    public bool refueling = false;
    Rigidbody2D myBody;

    public GameObject fireanimation;

    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        if (PlayerPrefs.GetString("landingBool") != "false" && PlayerPrefs.GetString("landingBool") != "true")
        {
            PlayerPrefs.SetString("landingBool", "false");
        }
    }

    void FixedUpdate()
    {
        Vector3 lookVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal_2"), CrossPlatformInputManager.GetAxis("Vertical_2"), 4096);

        if (lookVec.x != 0 && lookVec.y != 0)
        {
            Quaternion inputRotation = Quaternion.LookRotation(lookVec, Vector3.back);
            transform.rotation = Quaternion.Lerp(transform.rotation, inputRotation, rotationDamping);
        }

        if (CrossPlatformInputManager.GetAxis("Vertical") > 0 && GameObject.Find("FuelCont").GetComponent<Fuel>().fuelAmount > 0)
        {
            fireanimation.SetActive(true);

            if (this.GetComponent<OnGlowEnter>().entered)
            {
                transform.position = Vector3.MoveTowards(transform.position, this.GetComponent<OnGlowEnter>().enteredPlanet.transform.position, (moveForce / 2) * Time.deltaTime);
            }
            else
            {
                myBody.AddForce(((CrossPlatformInputManager.GetAxis("Vertical") + 1) / 2) * moveForce * transform.up);
            }

            if (moveForce < maxMoveForce)
            {
                moveForce += 1 * Time.fixedDeltaTime;
            }

            if (GameObject.Find("FuelCont").GetComponent<Fuel>().fuelAmount > 0)
            {
                    GameObject.Find("FuelCont").GetComponent<Fuel>().fuelAmount -= 0.8f * Time.fixedDeltaTime;
            }
        }
        else
        {
            fireanimation.SetActive(false);
        }

        if (refueling && GameObject.Find("FuelCont").GetComponent<Fuel>().fuelAmount < 100)
        {
            GameObject.Find("FuelCont").GetComponent<Fuel>().fuelAmount += 2.0f * Time.fixedDeltaTime;
        }

        if (SceneManager.GetActiveScene().name == "Landing")
        {
            if (myBody.gravityScale < 0.6)
            {
                myBody.gravityScale += 1 * Time.fixedDeltaTime;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            refueling = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            refueling = false;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            PlayerPrefs.SetString("landingBool", "true");
            SceneManager.LoadScene("MainLevel");
        }
    }
}