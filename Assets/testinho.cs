using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testinho : MonoBehaviour {
	Renderer eu;


	// Use this for initialization
	void Start () {
		
	}

	
	// Update is called once per frame
	void Update ()
	{
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.y > Screen.height || screenPosition.y < 0)
		{
			Destroy(gameObject);
		}
}}