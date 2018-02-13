using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;
public class TESTE : MonoBehaviour {





	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update(){
		transform.Translate (new Vector2 (0.1f, 0));

		transform.position = new Vector2 (
			Mathf.Clamp (transform.position.x, -320f, 0f),
			Mathf.Clamp (transform.position.y, -180, 180));
	}
}
