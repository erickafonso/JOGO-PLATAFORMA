using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
	public Transform target;
	Vector3 vectorToTarget;
	float angle;
	//float speed = 5f;
	// prints "close" if the z-axis of this transform looks
	// almost towards the target

	void Update()
	{	
		Debug.DrawRay (transform.position, vectorToTarget, Color.yellow);
		
		vectorToTarget = target.transform.position - transform.position;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
//		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		//transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);

	}
}