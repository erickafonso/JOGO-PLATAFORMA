using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testinhob : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag != "Finish") {
			Physics2D.IgnoreCollision (coll.gameObject.GetComponent<Collider2D> (), this.GetComponent<Collider2D> (), true);
		}

	}
}
