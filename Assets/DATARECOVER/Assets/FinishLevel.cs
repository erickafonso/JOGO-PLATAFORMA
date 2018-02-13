using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinishLevel : MonoBehaviour {
	bool Finish = false;
	Player jogador;
	public GameObject YouWin;
	// Use this for initialization
	void Start () {
		jogador = GetComponent<Player> ();
		YouWin.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		//printer ();
	}
	void printer(){
	//	if (Input.GetButtonDown ("Fire1")) {
	//		print ("penis");
	//		YouWin.SetActive (true);
	//	}
	}

	void OnTriggerEnter2D(Collider2D coll){
		
		//if(Finish == false){

			if (coll.gameObject.tag == "Player") {
			print ("penis");
				//jogador.enabled = false;
				Finish = true;
				YouWin.SetActive (true);
			//}

		}
	}

}
