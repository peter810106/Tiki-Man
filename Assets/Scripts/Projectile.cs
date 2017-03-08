using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	float speed = 10;

	public void Setspeed(float newSpeed) {
		speed = newSpeed;
	}
		
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
	}
}
