using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SwitchSceneEndAnim : MonoBehaviour {

    // Use this for initialization
    void Start () {
        StartCoroutine(Example());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Example()
    {
        yield return new WaitForSeconds(28);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
