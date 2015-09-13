using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {
	public Transform[] patrolPoints;
	public float moveSpeed;
	public GameObject laser;
	private int currentPoint;
	private int nextPos;

	// Use this for initialization
	void Start () {
		transform.position = patrolPoints [0].position;
		currentPoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position == patrolPoints [currentPoint].position) {
			nextPos = Random.Range(0, patrolPoints.Length);
			currentPoint = nextPos;
		}

		int shouldFire = Random.Range (0, 10000);
		if (shouldFire % 400 == 0) {
			Instantiate(laser, transform.position, Quaternion.identity);
			Vector3 playerPosition = GameObject.Find("Player").transform.position;
			laser.transform.LookAt(playerPosition);
			laser.transform.position += Vector3.forward;
		}

		transform.position = Vector3.MoveTowards (
			transform.position,
			patrolPoints [nextPos].position,
			moveSpeed * Time.deltaTime
		);
	
	}
}
