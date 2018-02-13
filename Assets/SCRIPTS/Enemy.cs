using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public Transform Player;
	Rigidbody2D myBody;
	// Transform myTrans;
	public float speed = 1f;
	public  int EnemyLife = 500;
	public  int DamageToHero = 100;
	public  int DamageFromHero;
	public HeroVida Vida;
	public bool HitPlayer = false;
	// Use this for initialization
	void Start () {
		Vida = GetComponent<HeroVida>();
		myBody = this.GetComponent<Rigidbody2D> ();

	}

	// Update is called once per frame
	void Update () {

		if (EnemyLife <= 0) {
			Destroy (gameObject);
		}
		if(HeroVida.Vivo){
		//	if (CHchaser.ChasePlayer) {
				//print ("ChasePlayer");
				Chase ();	
			}
		}
//	}

	void OnCollisionEnter2D(Collision2D other) {
		if (movements.invincible == false) {
			if (other.gameObject.tag == "Player") {
				DealDamage ();



			}
		}
		if (other.gameObject.tag == "Bullet") {
			TakeDamage ();



		}
	}

	void DealDamage() {
		HeroVida.currentHealth -= DamageToHero;
		print (HeroVida.currentHealth);
		StartCoroutine(movements.invincibler());
		movements.invincibler ();
	
	}
		void TakeDamage(){
		EnemyLife -= bulletBehavior.BulletDmg;
		print (EnemyLife);
	}
		public void Chase ()
	{
		float difference = Player.transform.position.x - transform.position.x;
		if (difference > 0.1f) {
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		}
		if (difference < -0.1f) {
			transform.Translate (-Vector2.right * speed * Time.deltaTime);
			//myBody.velocity = new Vector2(-speed,0);
		}
		if (difference < 0.1f && difference > -0.1f && Player.transform.position.y > transform.position.y) {
			myBody.AddForce (transform.up * 10f);
		}
	}
}

