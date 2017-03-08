using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public Weapon weapon;
	public void Shoot() {
		if (weapon != null) {
			weapon.Shoot ();
		}
	}
}
