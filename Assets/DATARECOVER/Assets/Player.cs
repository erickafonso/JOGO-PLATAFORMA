using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	SpriteRenderer m_SpriteRenderer;
	//The Color to be assigned to the Renderer’s Material
	Color m_NewColor;

	void Start () {
		//Fetch the SpriteRenderer from the GameObject
		m_SpriteRenderer = GetComponent<SpriteRenderer>();
		//Set the GameObject's Color quickly to a set Color (blue)

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Ignore Collision
	IEnumerator OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Enemy") {
			//print ("tocou");
			StartCoroutine(TakeDamage());
			TakeDamage ();
			Physics2D.IgnoreCollision (coll.gameObject.GetComponent<Collider2D> (), GetComponent<Collider2D> (), true);
			yield return new WaitForSeconds (2);
			//print ("2 segundos depois");
			m_SpriteRenderer.color = Color.white;
			Physics2D.IgnoreCollision (coll.gameObject.GetComponent<Collider2D> (), GetComponent<Collider2D> (), false);

		}
	}
	//Change Sprite Color after damage
	IEnumerator TakeDamage(){
		m_SpriteRenderer.color = Color.red;
		yield return new WaitForSeconds (0.06f);
		//print ("2 segundos depois");
		m_SpriteRenderer.color = Color.white;
	}
}
