using UnityEngine;
using System.Collections;

public class BackgroundAnim : MonoBehaviour
{
    public float speed = 0.5f;

    void LateUpdate()
    {
        Vector2 offset = new Vector2(0, Time.time * speed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}