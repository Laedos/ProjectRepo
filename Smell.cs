using UnityEngine;
using System.Collections;

public class Smell : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void FixedUpdate (){
	}

	void OnTriggerEnter(Collider coll) {
				if (coll.gameObject.tag == "animal")  
						coll.GetComponentInChildren<SampleAnimal> ().isChased = true;
		}

	void OnTriggerExit(Collider coll) {
		if (coll.gameObject.tag == "animal")  
			coll.GetComponentInChildren<SampleAnimal> ().isChased = false;
	}
}