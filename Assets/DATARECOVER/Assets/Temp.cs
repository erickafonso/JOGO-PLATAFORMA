using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour {
	public Transform Enemy;
	Vector3 starter;
	int enemyN = 0;
	// Use this for initialization
	void Start () {
		starter = new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);
	}

	// Update is called once per frame
	void Update () {
		
	//	float h = Input.GetAxis("Horizontal");
		//if(Input.GetButton("Horizontal")){
		if (Input.GetButton ("Jump") && enemyN == 0) {
			//	h = 0;
			Instantiate (Enemy, transform.position, Quaternion.identity);
			enemyN += 1;
		} 
			//transform.Translate(1f*h,0,0);
		//}
	}
}
