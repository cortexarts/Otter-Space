using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnGlowEnter : MonoBehaviour {
    private string planetname;
    private bool collided = false;
    private bool leaving = false;
    public GameObject PopUp;

    // Use this for initialization
    void Start () {
		
	}

    void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, planetname);
        file.Close();
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
        if (coll.gameObject.tag == "Glow")
        {
            PopUp.SetActive(true);
            collided = true;
        }
        else if (coll.gameObject.tag == "Planet")
        {
            planetname = coll.gameObject.name;
            Save();
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
    }
}
