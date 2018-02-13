using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste1 : MonoBehaviour {
	public int coco = 3;
	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public virtual void printer(){
		print ("damage");
	}
	public virtual void OnCollisionEnter2D (Collision2D other)
	{
		//if (coll.gameObject.tag == "Player") {


	}
}
