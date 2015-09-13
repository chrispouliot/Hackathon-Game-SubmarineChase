using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float moveSpeed;
	public GameObject deathParticles;

	private float maxSpeed = 11.5f;
	private Vector3 input;
	private Vector3 spawn;

	// Use this for initialization
	void Start () {
		spawn = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		if (GetComponent<Rigidbody> ().velocity.magnitude < maxSpeed) {
			GetComponent<Rigidbody>().AddForce (input * moveSpeed);
		}
		int maxDistance = 20;
		if (transform.position.x > maxDistance || transform.position.y > maxDistance || transform.position.y < -2) {
			Die ();
		}
	}

	void OnCollisionEnter (Collision other) {
		if (other.transform.tag == "Enemy" || other.transform.tag == "Death Wall") {
			Die ();
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.transform.tag == "Goal") {
			GameManager.completeLevel();
		}
	}

	void Die(){
		Instantiate(deathParticles, transform.position, Quaternion.identity);
		transform.position = spawn;
	}
}
