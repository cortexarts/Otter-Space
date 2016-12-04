using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {
	public Transform target;
	
	public float MissileSpeed;
	private float turn = 2.5f;
	private float lastTurn=0f;

	private Rigidbody2D rocketRigidbody;
	
	void Awake(){
		rocketRigidbody=GetComponent<Rigidbody2D>();
	}
	
	void Start(){
		Invoke ("Explode", 5f);
	}
	
	void FixedUpdate(){				
		Quaternion newRotation = Quaternion.LookRotation(transform.position - target.position, Vector3.forward);
		newRotation.x = 0.0f;
		newRotation.y = 0.0f;
		transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * turn);
		rocketRigidbody.velocity=transform.up * MissileSpeed;
		if(turn<40f){
			lastTurn+=Time.deltaTime*Time.deltaTime*50f;
			turn+=lastTurn;
		}
	}
	
	private void Explode(){
		CancelInvoke("Explode");
		Destroy(gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Enemy")){
			Explode ();
		}
	}
}
