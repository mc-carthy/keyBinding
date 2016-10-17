using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;


public class KeybindDialogue : MonoBehaviour {

	private InputManager inputManager;
	[SerializeField]
	private GameObject keyItemPrefab;
	[SerializeField]
	private GameObject keyList;
	private string buttonToRebind = null;
	private Dictionary<string, Text> buttonToLabel;

	private void Start () {
		inputManager = GameObject.FindObjectOfType<InputManager> ();
		string[] buttonNames = inputManager.GetButtonNames ();
		buttonToLabel = new Dictionary<string, Text> ();

		for (int i = 0; i < buttonNames.Length; i++) {
			string bn;
			bn = buttonNames [i];

			GameObject go = (GameObject)Instantiate (keyItemPrefab);
			go.transform.SetParent (keyList.transform);
			go.transform.localScale = Vector3.one;

			Text buttonNameText = go.transform.Find ("buttonName").GetComponent<Text> ();
			buttonNameText.text = bn;

			Text keyNameText = go.transform.Find ("keyNameButton/keyName").GetComponent<Text> ();
			keyNameText.text = inputManager.GetKeyNameForButton (bn);
			buttonToLabel [bn] = keyNameText;


			Button keybindButton = go.transform.Find ("keyNameButton").GetComponent<Button> ();
			keybindButton.onClick.AddListener ( () => { StartRebindFor(bn); } );
		}
	}

	private void Update () {
		if (buttonToRebind != null) {
			if (Input.anyKeyDown) {
				foreach (KeyCode kc in Enum.GetValues (typeof(KeyCode))) {
					if (Input.GetKeyDown (kc)) {
						inputManager.SetButtonForKey (buttonToRebind, kc);
						buttonToLabel [buttonToRebind].text = kc.ToString ();
						buttonToRebind = null;
						break;
					}
				}
			}
		}
	}

	private void StartRebindFor(string buttonName) {
		buttonToRebind = buttonName;
	}
}
