using UnityEngine;
using System.Collections;

public class ShootingBow : MonoBehaviour {
	public GameObject Projectile;
	public float Cooldown = 0.2f;
	private float InnerCooldown;
	public float Power;
	public float MaxPower = 130f;
	// Use this for initialization
	void Start () {
		InnerCooldown = 0f;
		Power = 30f;
	}
	
	// Update is called once per frame
	void Update () {
		if(InnerCooldown > 0){
			InnerCooldown -= Time.deltaTime;
		}
		if (Input.GetButtonUp("Fire1")) {
			//if(InnerCooldown <=0){
			Fire();        
			//      InnerCooldown = Cooldown;
			//}
			
		}
		if (Input.GetButton ("Fire1")) {
			
			Power += MaxPower * Time.deltaTime;
			if(Power > MaxPower){
				Power = MaxPower;
			}
		}
		//Input.Getb
	}
	
	void Fire(){
		Debug.Log ("Fire!");
		GameObject arrow;
		arrow = Instantiate (Projectile, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z) , Camera.main.transform.rotation) as GameObject;
		arrow.GetComponent<Arrow> ().Power = Power;
		arrow.transform.position += arrow.transform.TransformDirection (Vector3.forward*1.5f);
		
	}
}

