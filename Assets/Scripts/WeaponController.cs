using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {


	public Weapon weapon;
	public Transform weaponHold;

	void Start() {
		if (weapon != null) {
			EquipWeapon (weapon);
		}
	}

	public void EquipWeapon(Weapon weaponToEquip) {
		if (weapon != null) {
			Destroy (weapon.gameObject);
		}
		weapon = Instantiate (weaponToEquip, weaponHold.position, weaponHold.rotation ) as Weapon;
		weapon.transform.parent = weaponHold;
	}

	public void Shoot() {
		if (weapon != null) {
			weapon.Shoot ();
		}
	}
}
