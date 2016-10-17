using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class InputManager : MonoBehaviour {

	Dictionary<string, KeyCode> buttonKeys;

	private void OnEnable () {
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

	public string[] GetButtonNames() {
		return buttonKeys.Keys.ToArray ();
	}

	public string GetKeyNameForButton (string buttonName) {
		if (buttonKeys.ContainsKey (buttonName)) {
			return buttonKeys [buttonName].ToString ();
		} else {
			Debug.LogError ("InputManager::GetKeyNameForButton -- No button named " + buttonName);
			return "N/A";
		}
	}

	public void SetButtonForKey (string buttonName, KeyCode keyCode) {
		buttonKeys [buttonName] = keyCode;
	}
}