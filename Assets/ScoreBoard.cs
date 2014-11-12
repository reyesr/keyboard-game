using UnityEngine;
using System.Collections;

public class ScoreBoard : MonoBehaviour {
	private int score;
	
	public void add(int value) {
		score += value;
		GetComponent<GUIText> ().text = "Score: " + score;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
