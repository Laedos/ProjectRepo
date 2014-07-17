using UnityEngine;
using System.Collections;


public class Wind : MonoBehaviour {

	public Vector3 wind = new Vector3(0, 0, 0);
	private Vector3 newWind;
	private float defaultCountdown = 20f;
	private float countdown;

	public Vector3 GetWind(){
		return wind;
	}

	// Use this for initialization
	void Start () {
		countdown = 5f;

	}
	
	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;
		wind = Vector3.Lerp(wind, newWind, Time.deltaTime/5);
		if (countdown <= 0) {
				newWind.x = Random.Range(-8,8);
				newWind.z = Random.Range(-8,8);
				countdown = defaultCountdown;
				}
		}
}
