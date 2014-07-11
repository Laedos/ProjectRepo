using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour 
{
	private GameObject character;
	private CharacterController cc;
	public float speed = 0.1f;
	public float RotationSpeed = 0.1f;
	private Vector3 vec;
	private float jump = 0f;
	public float JumpHeight = 7f;
	private Vector3 temp;

	private Animator anim;

	// Use this for initialization
	void Start () 
	{
		character = GameObject.FindGameObjectWithTag ("Player");
		cc = character.GetComponent<CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate (0, Input.GetAxis("Mouse X") * RotationSpeed * 100, 0);
		jump += Physics.gravity.y * Time.deltaTime;
		if (cc.isGrounded) {
			if (Input.GetButtonDown ("Jump")) {
				jump = JumpHeight;
			}
			temp = transform.TransformDirection (Input.GetAxis ("Horizontal") * speed, jump, Input.GetAxis ("Vertical") * speed);
			vec = temp;
		} else {
			vec = new Vector3(temp.x * 0.75f, jump, temp.z * 0.75f);
		}
		cc.Move (vec * Time.deltaTime);
		anim.SetFloat ("speed", cc.velocity.magnitude);
	}
	

	void OnControllerColliderHit(ControllerColliderHit other){
		if (other.gameObject.tag == "boulder") {
			other.rigidbody.AddForce (transform.forward * speed);
		}

	}
	
	
}