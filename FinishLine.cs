using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

	public GUIText winLoseText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "boulder") {
					winLoseText.text = "You win!";
					resetLevel ();
			}
	}

	public void resetLevel() {
		Application.LoadLevel (0);
	}
}
