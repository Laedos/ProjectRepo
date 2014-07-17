using UnityEngine;
using System.Collections;

public class SampleAnimal : MonoBehaviour, IAnimal {

	bool isDamaged = false;
	public bool isChased = false;

	private int farSight = 3;
	
	private float walkSpeed = 1.0f;
	private float runSpeed = 5.0f;
	private float walkingTime = 0;
	private float rotationTime = 0;

	private Vector3 moveDirection = Vector3.forward;
	private Vector3 rotation = Vector3.zero;

	private HpScript hpScript;

	private GameObject player;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
		hpScript = gameObject.GetComponentInChildren<HpScript> ();
		hpScript.SetHp (100f);
	}

	void Update() {
			if (isDamaged || isChased) {
						RunAway ();		
				} else if (((player.transform.position) - (transform.position)).magnitude < farSight) {
						RunAwayFromPlayer ();
				} else {
						Walk ();
				}			
	}

	public void Walk () {
		if (walkingTime > 5) {
			walkSpeed = 0f;
		}
		if (walkingTime > 7) {
			walkSpeed = 1f; 
			walkingTime = 0;
			rotationTime = 0;
			rotation = new Vector3 (0, Random.Range (-2f, 2f), 0);
		}
		if (rotationTime > 1) {
			rotation = Vector3.zero;
				}
		transform.Rotate (rotation);
		transform.Translate (moveDirection * walkSpeed * Time.deltaTime);
		walkingTime += Time.deltaTime;
		rotationTime += Time.deltaTime;
	}

	public void RunAway () {
		if (walkingTime > 2) {
			walkingTime = 0;
			rotationTime = 0;
			rotation = new Vector3 (0, Random.Range (-2f, 2f), 0);
		}
		if (rotationTime > 0.5f) {
			rotation = Vector3.zero;
		}
		transform.Rotate (rotation);
		transform.Translate (moveDirection * runSpeed * Time.deltaTime);
		walkingTime += Time.deltaTime;
		rotationTime += Time.deltaTime;
	}

	public void RunAwayFromPlayer() {
		Vector3 fromPlayer = new Vector3 ((transform.position.x - player.transform.position.x), 0, (transform.position.z - player.transform.position.z));
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation(fromPlayer), Time.deltaTime * 1);
		transform.Translate (moveDirection * runSpeed * Time.deltaTime);
		}

	public void Stand(){
		transform.Translate (Vector3.zero);
	}

	public void Kill() {
		this.enabled = false;
	}
}