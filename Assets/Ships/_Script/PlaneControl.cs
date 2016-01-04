using UnityEngine;
using System.Collections;

public class PlaneControl : MonoBehaviour {
	Rigidbody2D playerRig;
	public float currentAngularVel = 0;
	public float AngularFirction = 0.99f;
	public float AngularSpeed = 10;
	public float speed = 5;

	public float fireRate;

	public float maxSpeed = 5;
	public float maxAngularVel = 50;

	private float currentFireRate;
	public GameObject bullets;
	public Transform bulletPos;

	void Start()
	{
		playerRig = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
		
		currentFireRate += Time.deltaTime;

		if(Input.GetAxis("Vertical") == 1)
			playerRig.AddForce (playerRig.gameObject.transform.up*speed);


		if (Input.GetAxis ("Horizontal") == 0)
			currentAngularVel *= AngularFirction;
		else {
			
			currentAngularVel -= Input.GetAxis ("Horizontal") * AngularSpeed;
			if (currentAngularVel > 0 && currentAngularVel > maxAngularVel)
				currentAngularVel = maxAngularVel;
			else if(currentAngularVel < 0 && currentAngularVel < -maxAngularVel)
				currentAngularVel = -maxAngularVel;
		}

		if (Input.GetButton ("Jump") && currentFireRate> fireRate)
		{
			currentFireRate = 0;
			Instantiate (bullets, bulletPos.transform.position, this.transform.rotation);
		}
		playerRig.angularVelocity = currentAngularVel;
	}

}
