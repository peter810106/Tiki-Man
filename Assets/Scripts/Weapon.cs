using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public Transform muzzle;
	public Projectile projectile;
	public float msBetweenShots = 100;
	public float muzzleVelocity = 35;

	float nextShortTime;

	public void Shoot() {

		if (Time.time > nextShortTime) {
			nextShortTime = Time.time + msBetweenShots / 1000;
			Projectile newProjectile = Instantiate (projectile, muzzle.position, muzzle.rotation) as Projectile;
			newProjectile.Setspeed (muzzleVelocity);
		}


	}
}
