using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "weapon")
			Debug.Log ("i got damage");
	}
	

}
