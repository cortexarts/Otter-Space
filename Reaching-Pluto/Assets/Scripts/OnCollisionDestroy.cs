using UnityEngine;
using System.Collections;

public class OnCollisionDestroy : MonoBehaviour
{
    public int incMoney;
    public int incExp;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            GameMaster.Money += incMoney;
            GameMaster._curExp += incExp;
            Destroy(gameObject);
        }
    }
}