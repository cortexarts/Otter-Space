using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueHandler : MonoBehaviour
{
    public Text dialogue;
    private string planetname;

    void Start()
    {
        planetname = PlayerPrefs.GetString("PlayerProgress");
        if (planetname == "Moon")
        {
            dialogue.text = "You are approaching the Moon! Maybe you will be the first to sea the otter side of the moon. Make sure to land safely and gather as many resources as possible.";
        }
        else if (planetname == "Mars")
        {
            dialogue.text = "You are approaching Mars! Make sure to land safely and gather as many resources as possible.";
        }
        else
        {
            dialogue.text = "You are approaching a planet where there isn't an actual dialogue. :/";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
