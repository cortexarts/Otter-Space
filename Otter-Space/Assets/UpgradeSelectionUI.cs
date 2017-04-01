using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeSelectionUI : MonoBehaviour
{
    public Text UITitle;
    public Text UIDescription;

    public void OnFuel()
    {
        UITitle.text = "Fuel";
        UIDescription.text = "Upgrade your fuel capacity to travel longer and reach further planets.";
    }
    public void OnThrusters()
    {
        UITitle.text = "Thrusters";
        UIDescription.text = "Upgrade your thrusters to travel faster and reach further planets.";
    }
    public void OnEngine()
    {
        UITitle.text = "Engine";
        UIDescription.text = "Upgrade your thrusters to travel faster and reach further planets.";
    }
    public void OnHull()
    {
        UITitle.text = "Hull";
        UIDescription.text = "Upgrade your hull to protect yourself from obstacles in space.";
    }
}
