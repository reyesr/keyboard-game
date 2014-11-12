using UnityEngine;
using System.Collections;

public class TextProvider {
	static char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\n','\r' };

	private string[] tokens;
	private int offset = 0;
	public TextProvider() {
		TextAsset txt = (TextAsset)Resources.Load("wordlists/us1", typeof(TextAsset));
		tokens = txt.text.Split (delimiterChars);
		if (tokens.Length == 0) {
			tokens = new string[1] {
				"sorry, an error occurred"
			};
		}
	}

	public string GetText() {
		int offset = (int)Random.Range (0, tokens.Length - 1);
		return tokens [offset];
	}

}
