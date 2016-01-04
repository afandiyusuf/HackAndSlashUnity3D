using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	Rigidbody2D thisRig;

	// Use this for initialization
	void Start () {
		thisRig = GetComponent<Rigidbody2D> ();
		Vector2 direction = transform.up*10;


		thisRig.velocity = direction;
	}
	

}
