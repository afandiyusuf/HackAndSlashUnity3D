using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	Rigidbody2D thisRig;	
	public float MS;
	public float JumpForce;
	public bool atGround;
	float currentSpeed;
	public string[] combos;
	public int currentCombo;
	public float AS;
	private float ASCalculator;
	private bool canAttack = false;
	private float comboDelay;

	public Animator handAnimator;
	// Use this for initialization
	void Start () {
		comboDelay = AS * 2;
		thisRig = GetComponent<Rigidbody2D> ();
	}

	void Update()
	{
		ASCalculator += Time.deltaTime;
		//player udah lama gak attack lagi, jadi combonya direset ulang
		if (ASCalculator > comboDelay)
			currentCombo = 0;
		
		if (Input.GetMouseButton (1) && canAttack)
			Attack ();
		
		if (ASCalculator > AS)
			canAttack = true;
	}
	void FixedUpdate()
	{
		currentSpeed = Input.GetAxis ("Horizontal")*MS;
		thisRig.velocity  = new Vector2(currentSpeed, thisRig.velocity.y);

		if (Input.GetButton ("Jump") && atGround) {
			atGround = false;
			thisRig.AddForce (Vector2.up * JumpForce);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "platform")
			atGround = true;
	}

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "platform")
			atGround = true;
	}

	void Attack()
	{
		ASCalculator = 0;
		canAttack = false;
		handAnimator.SetTrigger (combos [currentCombo]);
		currentCombo++;
		if (currentCombo >= combos.Length)
			currentCombo = 0;
	}




}
