using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnGlowEnter : MonoBehaviour {
    private string planetname;
    public bool entered = false;
    private bool leaving = false;
    public bool leavingEarth = false;
    public Transform enteredPlanet;
    public GameObject PopUp;
    Rigidbody2D myBody;

    // Use this for initialization
    void Start ()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        if (PlayerPrefs.GetString("landingBool") != "false" && PlayerPrefs.GetString("landingBool") != "true")
        {
            PlayerPrefs.SetString("landingBool", "false");
        }
    }

    // Update is called once per frame
    void Update () {
        if (entered)
        {
            if (Camera.main.orthographicSize > 49)
            {
                Camera.main.orthographicSize = 49;
            }
            else
            {
                Camera.main.orthographicSize += 8.0f * Time.deltaTime;
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
        if (coll.gameObject.tag == "Planet" && PlayerPrefs.GetString("landingBool") == "false")
        {
            PopUp.SetActive(true);
            entered = true;
            enteredPlanet = coll.gameObject.transform;
            planetname = coll.gameObject.name;
            PlayerPrefs.SetString("PlayerProgress", planetname);
        }
     }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Planet" && PlayerPrefs.GetString("landingBool") == "false" && coll.gameObject.name != "Death_star")
        {
            entered = false;
            planetname = coll.gameObject.name;
            PlayerPrefs.SetFloat("fuelAmount", GameObject.Find("FuelCont").GetComponent<Fuel>().fuelAmount);

            SceneManager.LoadScene("Landing");
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Glow")
        {
            PopUp.SetActive(false);
            leaving = true;
        }
        else if (coll.gameObject.name == "SoundTrigger")
        {
            leavingEarth = true;
            myBody.gravityScale = 0;
        }
    }
}
