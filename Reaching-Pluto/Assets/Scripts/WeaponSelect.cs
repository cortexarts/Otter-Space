using UnityEngine;
using System.Collections;

public class WeaponSelect : MonoBehaviour {

    /*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("space has been pressed.");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("space has been pressed.");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("space has been pressed.");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("space has been pressed.");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("space has been pressed.");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Debug.Log("space has been pressed.");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Debug.Log("space has been pressed.");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Debug.Log("space has been pressed.");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Debug.Log("space has been pressed.");
        }
    }*/

    public GameObject[] weapons; // push the prefabs


    private int nrWeapons;

    /*Weapons to pick up
    public bool JinR5 = true;
    public bool LongshotR1 = false;
    public bool HollaR4 = false;
    public bool BlizzR2 = false;
    public bool HammerR1 = false; */

    public enum WepEnum { JinR5, LongshotR1,  HollaR4,  BlizzR2,  HammerR1};
    public bool[] weaponState = new bool[WepEnum.GetNames(typeof(WepEnum)).Length];

    public int currentWeapon = (int)WepEnum.JinR5;
    
    void Start()
    {
        //for (int i = 0; i < weaponState.Length; i++)
        foreach (WepEnum wepEnum in WepEnum.GetValues(typeof(WepEnum)))
        {
            weaponState[(int)wepEnum] = true;
        }
        weaponState[(int)WepEnum.JinR5] = true;

        nrWeapons = weapons.Length;

        SwitchWeapon(currentWeapon); // Set a default gun

    }

    public void setWeapon(GameObject gameObject)
    {
        WepEnum wepEnum = (WepEnum)WepEnum.Parse(typeof(WepEnum), gameObject.name);
        weaponState[(int)wepEnum] = true;
    }

    void Update()
    {
        for (int i = 1; i <= nrWeapons; i++)
        {
            if (Input.GetKeyDown("" + i))
            {
                SwitchWeapon(i - 1);
            }
        }

    }

    void SwitchWeapon(int index)
    {
      if(  weaponState[index])
        {
            weapons[currentWeapon].gameObject.SetActive(false);
            weapons[index].gameObject.SetActive(true);
            currentWeapon = index;
        }
    }
}
