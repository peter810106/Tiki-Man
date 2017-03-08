using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent (typeof (WeaponController))]
public class Player : MonoBehaviour {
	
	Weapon weapon;
	WeaponController weaponController;

	void Start() {
		weaponController = GetComponent<WeaponController> ();
	}


	void Update() {
		
		if (Input.GetMouseButton (0)) {
			weapon.Shoot ();
		}
	}
}
