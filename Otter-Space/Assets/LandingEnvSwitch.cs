using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class LandingEnvSwitch : MonoBehaviour {
    private string planetname = "Moon";

    public GameObject Earth;
    public GameObject Moon;
    public GameObject Mars;

	// Use this for initialization
	void Start () {
        BinaryFormatter bf = new BinaryFormatter();
        //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
        FileStream file = File.Create(Application.persistentDataPath + "/playerprogress.gd"); //you can call it anything you want
        bf.Serialize(file, planetname);
        file.Close();

        //Switchin env
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
    }
}
