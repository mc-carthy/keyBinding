using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb;

	private bool doJump = false;
	[SerializeField]
	private float jumpSpeed = 10f;

	private void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	private void Update () {
		if (Input.GetButtonDown ("Jump")) {
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
