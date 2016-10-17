using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb;
	private InputManager inputManager;

	private bool doJump = false;
	[SerializeField]
	private float jumpSpeed = 10f;

	private void Start () {
		rb = GetComponent<Rigidbody2D> ();
		inputManager = GameObject.FindObjectOfType<InputManager> ();
	}

	private void Update () {
		if (inputManager.GetButtonDown ("Jump")) {
			doJump = true;
		}
	}

	private void FixedUpdate () {
		if (doJump) {
			doJump = false;
			rb.velocity = Vector2.up * jumpSpeed;
		}
	}
}
