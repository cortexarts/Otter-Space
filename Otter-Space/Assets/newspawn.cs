using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class newspawn : MonoBehaviour
{
    private string planetname;
    public GameObject moonspawn;
    public GameObject earthspawn;
    public GameObject marsspawn;
    public GameObject jupiterspawn;
    public GameObject mercspawn;
    public GameObject neptspawn;
    public GameObject satspawn;
    public GameObject urspawn;
    public GameObject plutspawn;
    public GameObject venspawn;
    public GameObject sunpsawn;

    // Use this for initialization
    void Start () {
        if (PlayerPrefs.GetString("landingBool") == "true")
        {
            planetname = System.IO.File.ReadAllText("PlayerProgress.txt");
            //Switching env
            if (planetname == "Moon")
            {
                gameObject.transform.position = moonspawn.transform.position;
            }
            else if (planetname == "Earth")
            {
                gameObject.transform.position = earthspawn.transform.position;
            }
            else if (planetname == "Mars")
            {
                gameObject.transform.position = marsspawn.transform.position;
            }
            else if (planetname == "Jupiter")
            {
                gameObject.transform.position = jupiterspawn.transform.position;
            }
            else if (planetname == "Mercurius")
            {
                gameObject.transform.position = mercspawn.transform.position;
            }
            else if (planetname == "Neptune")
            {
                gameObject.transform.position = neptspawn.transform.position;
            }
            else if (planetname == "Saturn")
            {
                gameObject.transform.position = satspawn.transform.position;
            }
            else if (planetname == "Uranus")
            {
                gameObject.transform.position = urspawn.transform.position;
            }
            else if (planetname == "Venus")
            {
                gameObject.transform.position = venspawn.transform.position;
            }
            else if (planetname == "Pluto")
            {
                gameObject.transform.position = plutspawn.transform.position;
            }
            else if (planetname == "Sun")
            {
                gameObject.transform.position = sunpsawn.transform.position;
            }
            //Add velocity!
            PlayerPrefs.SetString("landingBool", "false");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
