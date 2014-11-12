using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
	
	public GameObject ennemyPrefab;
	static float angleRange = 45;
	float nextEnnemyTimer = 0.5f;

	void Start () {
		ennemyPrefab = Resources.Load ("TextEl") as GameObject;
	}

	void Update () {
		nextEnnemyTimer -= Time.deltaTime;
		if (nextEnnemyTimer<0) {
			nextEnnemyTimer = 2;
			startNewTextEnnemy();
		}
	}
	
	void startNewTextEnnemy() {

		float angleh = Random.Range (-60, 60);
		float anglev = Random.Range (-angleRange, angleRange);
		float howfar = Random.Range (-100, -50);

		GameObject go = Instantiate(ennemyPrefab, new Vector3 (-20, 0, 4), Quaternion.identity) as GameObject;
		go.SetActive (true);
		go.transform.Translate (new Vector3 (howfar, anglev, angleh) * 5);
	}


}
