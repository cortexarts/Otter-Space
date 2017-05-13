using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;
using UnityEngine;

public class LandingEnvSwitch : MonoBehaviour {
    private string planetname;

    public GameObject Earth;
    public GameObject Moon;
    public GameObject Mars;
    public GameObject Jupiter;
    public GameObject Mercurius;
    public GameObject Neptune;
    public GameObject Saturn;
    public GameObject Uranus;
    public GameObject Venus;
    public GameObject Pluto;
    public GameObject Sun;

    // Use this for initialization
    void Start () {
        //Reading progress
        planetname = PlayerPrefs.GetString("PlayerProgress", planetname);

        //Switching env
        if (planetname == "Moon")
        {
            Moon.SetActive(true);
        }
        else if (planetname == "Earth")
        {
            Earth.SetActive(true);
        }
        else if (planetname == "Mars")
        {
            Mars.SetActive(true);
        }
        else if (planetname == "Jupiter")
        {
            Jupiter.SetActive(true);
        }
        else if (planetname == "Mercurius")
        {
            Mercurius.SetActive(true);
        }
        else if (planetname == "Neptune")
        {
            Neptune.SetActive(true);
        }
        else if (planetname == "Saturn")
        {
            Saturn.SetActive(true);
        }
        else if (planetname == "Uranus")
        {
            Uranus.SetActive(true);
        }
        else if (planetname == "Venus")
        {
            Venus.SetActive(true);
        }
        else if (planetname == "Pluto")
        {
            Pluto.SetActive(true);
        }
        else if (planetname == "Sun")
        {
            Sun.SetActive(true);
        }
    }
}
