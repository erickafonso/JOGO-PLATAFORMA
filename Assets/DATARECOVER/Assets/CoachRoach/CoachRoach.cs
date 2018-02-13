using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;
public class CoachRoach : Enemyb {
	Animator coach;
	Enemyb EnemyScript;
	bool Jump = true;
	private bool grounded = false;

	// Use this for initialization
	void Start () {
		
		DamageToHero = 50;
		EnemyHP = 100;
		coach = GetComponent<Animator> ();
		EnemyScript = GetComponent<Enemyb> ();
		StartCoroutine (JumP ());
	}
	
	// Update is called once per frame
	 void Update () {
		Debug.DrawRay (transform.position, -Vector2.up);
		grounded = Physics2D.Raycast(transform.position, -Vector2.up, 0.5f, 1 << LayerMask.NameToLayer ("Ground")); 

		if (!grounded) {
			coach.SetBool ("Jump", true);

		} else {
			coach.SetBool ("Jump", false);
		}
			
		print (grounded);
		Move();

		if (EnemyHP <= 0) {
			EnemyScript.DeadEnemy = true;
			gameObject.layer = 10;
			Die ();
		}


			

	}
	public override void DealDamage(){
		

		HeroVida.currentHealth -= DamageToHero;
	//	print (HeroVida.currentHealth);
		StartCoroutine(movements.invincibler());
		movements.invincibler ();
		print (HeroVida.currentHealth);


	}
	public override void TakeDamage (){
		EnemyHP -= bulletBehavior.BulletDmg;
		base.TakeDamage ();

	}

	public override void OnCollisionEnter2D(Collision2D other) {
		if (movements.invincible == false) {
			if (other.gameObject.tag == "Player") {

				DealDamage ();



			} else if (other.gameObject.tag == "Bullet") {
				TakeDamage ();
			} 

		}
	}
	void Die(){
		coach.SetBool ("Die", true);
		gameObject.layer = 10;
		//Destroy (gameObject, 2f);
	}

	void Move(){
		if (EnemyScript.is_moving == true){
			coach.SetBool ("Idle", false);
			coach.SetBool ("Move", true);
		} else {
			coach.SetBool ("Idle", true);
			coach.SetBool ("Move", false);
		}
	}

	IEnumerator JumP(){
		
		float JumpTime = Random.Range(5f , 10f);

		while (true)
		{
			yield return new WaitForSeconds(JumpTime);
			if (EnemyScript.DeadEnemy == true || grounded == false) {
				yield break;
			}	else{
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, 550f));

				}
	
			}
				
	}
}
