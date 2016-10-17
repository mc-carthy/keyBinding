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

		foreach (string bn in buttonNames) {
			GameObject go = (GameObject)Instantiate (keyItemPrefab);
			go.transform.SetParent (keyList.transform);
			go.transform.localScale = Vector3.one;

			Text buttonNameText = go.transform.Find ("buttonName").GetComponent<Text> ();
			buttonNameText.text = bn;

			Text keyNameText = go.transform.Find ("keyNameButton/keyName").GetComponent<Text> ();
			keyNameText.text = inputManager.GetKeyNameForButton (bn);
		}
	}
}
