using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent (typeof (WeaponController))]
public class Player : MonoBehaviour {
	
	Weapon weapon;
	WeaponController weaponController;
//	Camera viewCamera;

	void Start() {
		weaponController = GetComponent<WeaponController> ();
	}

	void Update() {
		float rayDistance;
//		Ray ray = viewCamera.ScreenPointToRay (Input.mousePosition);
		Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
		if (Input.GetMouseButton (0)) {
//			weapon.Shoot ();
//			LookAt(ray.GetPoint(out rayDistance));
			weaponController.Shoot();
		}
	}

	public void LookAt(Vector3 lookPoint) {
		transform.LookAt (lookPoint);
	}
}
