using UnityEngine;
using System.Collections;

public class CountdownTimer : MonoBehaviour {

	public GUIText timerText;
	private FinishLine finishLine;

	public float timer;
	public float timerLimit = 60.0f;

	// Use this for initialization
	void Start () {
		timer = timerLimit;
		finishLine = GameObject.Find ("FinishLine").GetComponent<FinishLine>();

	
	}
	
	// Update is called once per frame
	void Update () {
		timerText.text = "Time left: " + timer.ToString("f0");
		timer -= Time.deltaTime;
		if (timer <= 0.0f) {
			finishLine.winLoseText.text = "You lose!";
			finishLine.resetLevel();
			timer = timerLimit;
		}
	}
}
