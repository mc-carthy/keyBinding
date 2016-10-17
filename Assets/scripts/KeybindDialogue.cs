using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeybindDialogue : MonoBehaviour {

	private InputManager inputManager;
	[SerializeField]
	private GameObject keyItemPrefab;
	[SerializeField]
	private GameObject keyList;

	private void Start () {
		inputManager = GameObject.FindObjectOfType<InputManager> ();
		string[] buttonNames = inputManager.GetButtonNames ();

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

			Button keybindButton = go.transform.Find ("keyNameButton").GetComponent<Button> ();
			keybindButton.onClick.AddListener ( () => { StartRebindFor(bn); } );
		}
	}

	private void StartRebindFor(string buttonName) {
		Debug.Log ("Start rebind for: " + buttonName);
	}
}
