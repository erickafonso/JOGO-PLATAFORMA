using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour {

	public bool ChasePlayer = false;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
	//	if (Input.GetButtonDown ("Jump"))
	//		print ("cebola");
		//print(ChasePlayer);
		if (HeroVida.Vivo == false) {
			ChasePlayer = false;
		}
	}
	void OnTriggerEnter2D(Collider2D aCol){
		if (HeroVida.Vivo == true) {
			if (aCol.gameObject.tag == "Player") {
			
				ChasePlayer = true;
		
		
		
			}

		} else {
			aCol = null;
		}

	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			ChasePlayer = false;
		}


	}
}
