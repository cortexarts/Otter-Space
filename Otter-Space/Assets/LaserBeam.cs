using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserBeam : MonoBehaviour
{
    private bool _createdLaster = false;
    private Transform _playerTransform;

    void Start()
    {
        
    }

    void Update()
    {
        if (_createdLaster)
        {
            LineRenderer lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, _playerTransform.position);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _playerTransform = other.transform;
            _createdLaster = true;
        }
        else
        {
            Debug.Log("Colliding object is not a player!");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _createdLaster = false;
            LineRenderer lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, new Vector3(0.0f, 0.0f, 0.0f));
            lineRenderer.SetPosition(1, new Vector3(0.0f, 0.0f, 0.0f));
        }
        else
        {
            Debug.Log("Colliding object is not a player!");
        }
    }
}