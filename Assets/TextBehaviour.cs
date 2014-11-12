using UnityEngine;
using System.Collections;

public class TextBehaviour : MonoBehaviour {

	private static TextProvider textProvider = null;

	public float speed = 10f;
	bool killed = false;
	float deathTimer = 3f;
	Vector3 deathDirection;

	string displayText;
	string expectedText;

	// Use this for initialization
	void Start () {
		if (textProvider == null) {
			textProvider = new TextProvider();
		}
		BoxCollider col = (BoxCollider)collider;
		col.center = new Vector3(renderer.bounds.extents.x, renderer.bounds.extents.y - renderer.bounds.size.y, transform.position.z);
		col.size = new Vector3(renderer.bounds.size.x, renderer.bounds.size.y, 1);
		speed = Random.Range(3f, 20f);
		this.displayText = textProvider.GetText ();
		this.expectedText = displayText;
		GetComponent<TextMesh> ().text = displayText;

		EventManager.WordListeners += checkWord;

		deathDirection = new Vector3 (Random.Range(-100,+100), Random.Range(-100,+100), Random.Range (-100, +100));
	}

	void OnDisable() {
		EventManager.WordListeners -= checkWord;
		// print("script was removed");
		Debug.Log ("killing " + expectedText);
		Destroy (this);
	}
	

	void OnTriggerEnter(Collider other) {
		Debug.Log("triggerEnter !!");
	}


	public void checkWord(string word) {
		// Debug.Log ("Comparing " + word + " with " + expectedText);
		if (word.EndsWith(expectedText)) {
			// this.gameObject.SetActive(false);
			//Debug.Log ("killing " + expectedText);
			killed = true;
			ParticleSystem particle = gameObject.GetComponent("ParticleSystem") as ParticleSystem;			
			particle.enableEmission = true;
			MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>() as MeshRenderer;
			renderer.enabled = false;
			GameObject.Find("scoreboard").GetComponent<ScoreBoard>().add(+2);
		}
  	}

	// Update is called once per frame
	void Update () {
		GameObject camera = GameObject.Find ("Main Camera");
		// Moving toward the camera
		if (killed == true) {

			transform.position = Vector3.MoveTowards (this.transform.position, this.transform.position - deathDirection, speed * 3 * Time.deltaTime);
			deathTimer -= Time.deltaTime;
			if (deathTimer<0) {
				this.gameObject.SetActive(false);
			}

		} else {

			float distance = 0f;
			transform.position = Vector3.MoveTowards (this.transform.position, camera.transform.position, speed * Time.deltaTime);
			distance = Vector3.Distance (transform.position, camera.transform.position);
			if (distance > 1) {
				Vector3 direction = (transform.position - camera.transform.position).normalized;
				transform.rotation = Quaternion.LookRotation (direction);
			} else {
				this.gameObject.SetActive(false);
				GameObject.Find("scoreboard").GetComponent<ScoreBoard>().add(-1);
			}
		}
		// Rotating toward the camera


	}
}
