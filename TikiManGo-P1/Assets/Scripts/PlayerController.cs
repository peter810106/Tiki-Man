using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject tikiman;
	Material m;
	float amt;
	bool clicked;
	// Use this for initialization
	void Start () {
		amt = 0;
		//tikiman = GameObject.FindGameObjectWithTag ("PlayerMaterial");
		SkinnedMeshRenderer r = tikiman.GetComponent<SkinnedMeshRenderer> ();
		print (r);
		clicked = false;
		m = r.material;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			clicked = true;
		}

		if (clicked && amt <= 1) {
			amt += 0.01f;
			m.SetFloat ("_SliceAmount", amt);
		} else {
			clicked = false;
		}
	}
}
