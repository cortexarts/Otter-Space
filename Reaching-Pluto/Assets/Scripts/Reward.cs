using UnityEngine;
using System.Collections;

public class Reward : MonoBehaviour {

    public WeaponSelect weaponSelector;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            GameObject g = GameObject.FindGameObjectWithTag("WeaponSelector");
            weaponSelector = g.GetComponent<WeaponSelect>();

            weaponSelector.setWeapon(gameObject);

            Destroy(gameObject);
        }

    }
}
