using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControllerB : MonoBehaviour {

	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	public GameObject target;
	public Vector3 offset;
	Vector3 targetPos;
	// Use this for initialization
	void Start () {
		targetPos = transform.position;
	}

	// Update is called once per frame
	void Update(){
		
	}
	void FixedUpdate () {
		if (target) {
			Vector3 posNoZ = transform.position;
			posNoZ.z = target.transform.position.z;

			Vector3 targetDirection = (target.transform.position - posNoZ);

			interpVelocity = targetDirection.magnitude * 5f;

			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 

			transform.position = Vector3.Lerp (transform.position, new Vector3 (targetPos.x, 0, targetPos.z) + offset, 0.25f);
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x, -4.5f, 91f), 0, -5f);
		
				
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Bullet") {
		//	Destroy (other.gameObject);
		}
	}
	public void Restarter(){
			
				SceneManager.LoadScene( SceneManager.GetActiveScene().name );
			
		}

	}
