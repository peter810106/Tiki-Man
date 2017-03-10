using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
	/*
	[SerializeField]
	private float throwSpeed;
	private float speed;
	private float lastMouseX, lastMouseY;

	private bool thrown, holding;

	private Rigidbody _rigidBody;
	private Vector3 newPosition;


	// Use this for initialization
	void Start () {
		Input.simulateMouseWithTouches = true;
		_rigidBody = GetComponent<Rigidbody> ();
		Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		if (holding) {
			OnTouch ();
		}

		if (thrown) {
			return;
		}

		if (Input.touchCount == 1 && (Input.GetTouch(0).phase.Equals(TouchPhase.Began) || Input.GetMouseButtonDown(0))) {
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 1f)) {
				if (hit.transform == transform) {
					holding = true;
					transform.SetParent (null);
				}
			}
		}

		if (Input.touchCount == 1 && (Input.GetTouch(0).phase.Equals(TouchPhase.Ended)) || Input.GetMouseButtonUp(0)) {
			if (lastMouseY < Input.GetTouch(0).position.y) {
				ThrowFireball (Input.GetTouch(0).position);
			}
		}

		if (Input.touchCount == 1) {
			lastMouseX = Input.GetTouch (0).position.x;
			lastMouseY = Input.GetTouch (0).position.y;
		}
	}

	void Reset () {
		CancelInvoke ();
		transform.position = Camera.main.ViewportToWorldPoint (new Vector3 (0.5f, 0.1f, Camera.main.nearClipPlane * 7.5f));
		newPosition = transform.position;
		thrown = holding = false;

		_rigidBody.useGravity = false;
		_rigidBody.velocity = Vector3.zero;
		_rigidBody.angularVelocity = Vector3.zero;
		transform.rotation = Quaternion.Euler (0f, 200f, 0f);
		transform.SetParent (Camera.main.transform);
	}

	void OnTouch () {
		Vector3 mousePos = Input.GetTouch (0).position;
		mousePos.z = Camera.main.nearClipPlane * 7.5f;

		newPosition = Camera.main.ScreenToWorldPoint (mousePos);

		transform.localPosition = Vector3.Lerp (transform.localPosition, newPosition, 50f * Time.deltaTime);
	}

	void ThrowFireball (Vector2 mousePos) {
		_rigidBody.useGravity = true;

		float differenceY = (mousePos.y - lastMouseY) / Screen.height * 100;
		speed = throwSpeed * differenceY;

		float x = (mousePos.x / Screen.width) - (lastMouseX / Screen.width);
		x = Mathf.Abs (Input.GetTouch(0).position.x - lastMouseX) / Screen.width * 100 * x;

		Vector3 direction = new Vector3 (x, 0f, 1f);
		direction = Camera.main.transform.TransformDirection (direction);

		_rigidBody.AddForce ((direction * speed / 2f) + (Vector3.up * speed));

		holding = false;
		thrown = true;

		Invoke ("Reset", 5.0f);
	}
	*/

	Vector3 initPos;
	// Use this for initialization
	void Start () {
		initPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			transform.position = new Vector3(0f, 0f, 0f);
			//Rigidbody rb = GetComponent<Rigidbody> ();
			//rb.velocity = Camera.main.transform.forward * 5;
			print(transform.position);
		}
		Invoke ("Reset", 5.0f);
	}

	void Reset () {
		CancelInvoke ();
		transform.position = initPos;
		print("3");
	}
}
