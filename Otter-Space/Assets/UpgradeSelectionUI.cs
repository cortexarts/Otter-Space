using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeSelectionUI : MonoBehaviour
{
    public Text UITitle;
    public Text UIDescription;

    public GameObject rocket1;
    public GameObject rocket2;
    public GameObject rocket3;
    public GameObject rocket4;

    public void OnFuel()
    {
        UITitle.text = "Fuel";
        UIDescription.text = "Upgrade your fuel capacity to travel longer and reach further planets.";
    }
    public void OnSelectFuel()
    {
        rocket1.SetActive(false);
        rocket2.SetActive(true);
    }

    public void OnThrusters()
    {
        UITitle.text = "Thrusters";
        UIDescription.text = "Upgrade your thrusters to travel faster and reach further planets.";
    }
    public void OnSelectThrusters()
    {
        rocket1.SetActive(false);
        rocket2.SetActive(true);
    }

    public void OnEngine()
    {
        UITitle.text = "Engine";
        UIDescription.text = "Upgrade your engine to travel more efficiently by using less fuel.";
    }
    public void OnSelectEngine()
    {
        rocket1.SetActive(false);
        rocket3.SetActive(true);
    }

    public void OnHull()
    {
        UITitle.text = "Hull";
        UIDescription.text = "Upgrade your hull to protect yourself from obstacles in space.";
    }
    public void OnSelectHull()
    {
        rocket1.SetActive(false);
        rocket4.SetActive(true);
    }
}
