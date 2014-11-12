using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	string keybuffer;

	public delegate void WordInput(string word);
	static public WordInput WordListeners;

	void OnGUI()
	{
		Event e = Event.current;
		if (e.isKey && e.character > 0) {
			// Debug.Log ("key: " + e.character + "/" + e.keyCode);
			if (e.character == ' ' || e.character == 13 || e.character == 10) {
					Debug.Log ("word: " + keybuffer);
				keybuffer = "";
			} else if (e.character > 32) {
					keybuffer += e.character;
			}
			if (keybuffer.Length>0 && WordListeners != null) {
				if (keybuffer.Length>127) { // "640K ought to be enough for anybody"
					keybuffer = keybuffer.Remove(0,64); 
				}
				WordListeners(keybuffer);
			}

		} else if (e.isKey && e.type == EventType.KeyDown && e.keyCode == KeyCode.Backspace) {
			Debug.Log ("backspace");
		}
	}

}
