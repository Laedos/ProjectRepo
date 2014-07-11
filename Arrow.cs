

using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	public float Speed = 5.0f;
	public float ExpireTime = 1.0f;
	private HpScript HpScript = null;
	private float MaxMag;
	ShootingBow sb;
	// Use this for initialization
	void Start () {
		sb = GameObject.FindGameObjectWithTag ("Player").GetComponent<ShootingBow>();
		Speed = sb.Power;
		sb.Power = 30f;
		
		rigidbody.AddForce (transform.TransformDirection (Vector3.forward * Speed), ForceMode.Impulse);
		
		
	}
	void FixedUpdate(){
		
		rigidbody.AddForce (Physics.gravity * rigidbody.mass, ForceMode.Acceleration);
		
		transform.forward = Vector3.Slerp(transform.forward, rigidbody.velocity.normalized, 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (rigidbody.velocity.magnitude > MaxMag) {
			MaxMag = rigidbody.velocity.magnitude;
			//      Debug.Log ("Fired at " + rigidbody.velocity.magnitude + " mag.");
		}
		ExpireTime -= Time.deltaTime;
		if (ExpireTime <= 0) {
			Destroy (gameObject);
		}
	}
	
	void OnCollisionEnter(Collision coll){
		HpScript = coll.gameObject.GetComponent<HpScript> ();
		if (HpScript != null) {
			HpScript.ReceiveDamage(40f);
			gameObject.collider.enabled = false;
			rigidbody.isKinematic = true;
			rigidbody.useGravity = false;
			
			Destroy (this);
		}
		if ((coll.gameObject.CompareTag(gameObject.tag)) || coll.gameObject.tag == "Player" ) {
			Debug.Log ("SameType");
		} else {
			gameObject.collider.enabled = false;
			rigidbody.isKinematic = true;
			rigidbody.useGravity = false;
			
			Destroy (this);
			
		}
	}
	
	
}

