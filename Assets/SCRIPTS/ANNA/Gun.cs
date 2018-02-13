using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	public static float fireRate = 1.0f;
	public Rigidbody2D Projectile;				// Prefab of the rocket.
	public float speed = 0.01f;				// The speed the rocket will fire at.
	public int numOfBulletsInShot = 10;
	public static bool CanShoot = true;
	private movements playerCtrl;// Reference to the PlayerControl script.
	//	private HeroVida Alive;
	//private Animator anim;					// Reference to the Animator component.


	void Awake()
	{
		// Setting up the references.
		//anim = transform.root.gameObject.GetComponent<Animator>();
		playerCtrl = transform.root.GetComponent<movements>();
		//Alive = GetComponent <HeroVida>();
	}


	void Update ()
	{
		if (HeroVida.Vivo == true) {
			// If the fire button is pressed...
			if (CanShoot == true) {
				if (Input.GetButtonDown ("Fire1")) {
					StartCoroutine(Shooted());
					Shooted ();
					for (int i = 0; i < numOfBulletsInShot; i++) {
						float spreadAngle = Random.Range (-10, 10);
						float rotateAngle = spreadAngle + (Mathf.Atan2 (0, 0) * Mathf.Rad2Deg);
						Rigidbody2D bulletInstance = Instantiate (Projectile, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
						// ... set the animator Shoot trigger parameter and play the audioclip.
						//anim.SetTrigger("Shoot");
						GetComponent<AudioSource>().Play();
						var MovementDirection = new Vector2 (Mathf.Cos (rotateAngle * Mathf.Deg2Rad), Mathf.Sin (rotateAngle * Mathf.Deg2Rad)).normalized;
						// If the player is facing right...
						if (playerCtrl.facingRight) {
							// ... instantiate the rocket facing right and set it's velocity to the right. 

							bulletInstance.velocity = MovementDirection * speed;
						} else {
							// Otherwise instantiate the rocket facing left and set it's velocity to the left.

							bulletInstance.velocity = MovementDirection * -speed;
						}
					}
				}
			}
		}
	}
	public static IEnumerator Shooted ()
	{

		CanShoot = false;
		yield return new WaitForSeconds (fireRate);
		CanShoot = true;
	}
}
