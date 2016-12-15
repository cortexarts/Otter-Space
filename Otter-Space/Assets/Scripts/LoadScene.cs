using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	// Use this for initialization
	public void ChangeScene (int scene) {
        SceneManager.LoadScene(scene);
	}
}
