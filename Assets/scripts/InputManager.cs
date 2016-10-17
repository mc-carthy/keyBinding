using UnityEngine;
using System.Collections.Generic;

public class InputManager : MonoBehaviour {

	Dictionary<string, KeyCode> buttonKeys;

	private void Start () {
		buttonKeys = new Dictionary<string, KeyCode> ();

		// TODO - Read from user prefs file
		buttonKeys ["Jump"] = KeyCode.Space;
		buttonKeys ["Left"] = KeyCode.LeftArrow;
		buttonKeys ["Right"] = KeyCode.RightArrow;
	}

	public bool GetButtonDown (string buttonName) {
		if (buttonKeys.ContainsKey (buttonName)) {
			return Input.GetKeyDown (buttonKeys[buttonName]);
		} else {
			Debug.LogError ("InputManager::GetButtonDown -- No button named " + buttonName);
			return false;
		}
	}
}