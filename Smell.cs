using UnityEngine;
using System.Collections;

public class Smell : MonoBehaviour {

	GameObject characterPosition;
	Wind wind;

	// Use this for initialization
	void Start () {
		characterPosition = GameObject.FindGameObjectWithTag("Player");
		wind = GameObject.FindGameObjectWithTag ("wind").GetComponent<Wind> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = characterPosition.transform.position + wind.wind;
		
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