﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.tag == "Player")
            SceneManager.LoadScene(+1);
	}
}
