using UnityEngine;
using System.Collections;

public class MoveWithParent : MonoBehaviour {

    public GameObject parent;
    public float offsetY;
    public float offsetX;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(parent.transform.position.x + offsetX, parent.transform.position.y + offsetY, parent.transform.position.z);
    }
}
