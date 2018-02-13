using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class Enemyb : MonoBehaviour {

	public float distancePlayer;
	public float distanceAttack = 2f;
	public float destination;
	public LayerMask layermask;

	int Blocked = 0;

	RaycastHit2D hitA;
	RaycastHit2D hitB;
	RaycastHit2D hitC;

	private float speed = 2f;

	protected int EnemyHP = 300; 
	protected int DamageToHero = 100;
	HeroVida Vida;
	protected bool HitPlayer = false;


	private bool FacingRight = true;
	public bool is_moving = false;
	protected Rigidbody2D EnemyBody;

	public bool DeadEnemy = false;

	 Chaser CHchaser;
	 Transform Player;
	 Transform OriginPoint;
	private Vector2 dir = new Vector2(1, 0);
	private float range = 10f;
	private float rangeB = 1f;
	private float rangeC = 0.5f;


	[Task]
	private bool is_alive_player = true;

	[Task]
	private bool is_alive_enemy = true;

	[Task]
	private bool is_on_chaseRange = false;

	[Task]
	private bool is_Idle = true;

	[Task]
	private bool is_alert = false;


	[Task]
	private bool is_on_attackRange = false;

	[Task]
	private bool is_on_pointRange = false;

	[Task]
	private bool is_damaged = false;

	[Task]
	private void SetColor(float r, float g, float b)
	{
		this.GetComponent<Renderer>().material.color = new Color(r, g, b);
		Task.current.Succeed();

	}

	//PLAYER ENCOUNTER


	[Task]
	private void Chase ()
	{

		//print ("I'm Chasing");

		if (distancePlayer > 0f) {
			MoveRight ();
			is_moving = true;
			//transform.Translate (Vector2.right * speed * Time.deltaTime);
		}
		if (distancePlayer < 0f) {
			MoveLeft ();
			is_moving = true;
			//transform.Translate (Vector2.right * -speed * Time.deltaTime);
			//myBody.velocity = new Vector2(-speed,0);
		}
		//if (distancePlayer < 0.1f && distancePlayer > -0.1f && Player.transform.position.y > transform.position.y) {
		//EnemyBody.AddForce (transform.up * 10f);
		//}

		Task.current.Succeed ();

	}
	[Task]
	private void Attack () {
		is_Idle = false;
		is_moving = true;
		//print ("I'm attacking");
		//if (distancePlayer > 0f ) {
		if(hitB == true){
	//		EnemyBody.AddForce (transform.right * (500f * dir.x) );
			if (distancePlayer > 0f) {
				EnemyBody.AddForce (transform.right * (500f ) );

				//transform.Translate (Vector2.right * speed * Time.deltaTime);
			}
			if (distancePlayer < 0f) {
				EnemyBody.AddForce (transform.right * (-500f ) );
				//transform.Translate (Vector2.right * -speed * Time.deltaTime);
				//myBody.velocity = new Vector2(-speed,0);
			}
		}
		//else if (distancePlayer < 0f) {
		//	EnemyBody.AddForce (transform.right * -300f);

		//}
		Task.current.Succeed ();
	}

	//END PLAYER ENCOUNTER
	[Task]
	private void Alert(){
		print ("I'm alert");
		Task.current.Succeed ();
	}

	[Task]
	private void Patrol(){
		//	print ("I'm patroling");
		Task.current.Succeed ();

	}

	[Task]
	private void Idle () {
		is_Idle = true;
		is_moving = false;
		Task.current.Succeed ();
	}

	[Task]
	private void GenerateDestination(){
		if (is_damaged == true) {
			destination = Player.transform.position.x / 2f;
		}  else {
			if (hitC == false) {
				destination = transform.position.x + Random.Range (-10f, 10f);

			} else if (hitC == true && FacingRight == true) {
	//		else if (Blocked > 0 && FacingRight == true) {
				Flip();
				destination = transform.position.x + Random.Range (-10f, 0f);
			//	Blocked -= 1;
			}  else if (hitC == true && FacingRight == false) {
	//		else if (Blocked > 0 && FacingRight == false) {
				Flip();
				destination = transform.position.x + Random.Range (0f, 10f);
		//		Blocked -= 1 ;
			}
		}
		//else if (hitC == true && transform.position.x == 0) {
		//	destination = transform.position.x + Random.Range (-10f, 10f);
		//}
		//	print (Mathf.FloorToInt(destination));
		Task.current.Succeed ();
	}

	[Task]
	private void MoveToDestination(){
		is_Idle = false;
		is_moving = true;
		if (Mathf.FloorToInt(destination) > Mathf.FloorToInt(transform.position.x)) {
			
			MoveRight ();
			if (hitC == true) {
		//		Blocked = 1;
				is_moving = false;
				Task.current.Succeed ();
			}
			//transform.Translate (Vector2.right * 1f * Time.deltaTime);
			//Flip ();

		}

		else if (Mathf.FloorToInt(destination) < Mathf.FloorToInt(transform.position.x)) {
			
			MoveLeft ();
			if (hitC == true) {
			//	Blocked = 1;
				is_moving = false;
				Task.current.Succeed ();
			}
			//transform.Translate (-Vector2.right * 1f * Time.deltaTime);
			//Flip ();

		}
		else {
			print ("aproximado");
			is_moving = false;
			Task.current.Succeed ();
		}
		is_damaged = false;
	}

	//MOVEMENT

	void Flip(){

		FacingRight = !FacingRight;
		Vector3 scala = transform.localScale;
		scala.x *= -1;
		transform.localScale = scala;
		dir *= -1;
	}


	public virtual void MoveRight(){
		if (speed > 0 && !FacingRight) {
			Flip ();
		}
		transform.Translate (Vector2.right * speed * Time.deltaTime);

	}

	public virtual void MoveLeft(){
		if (-speed < 0 && FacingRight) {

			Flip ();

		}
		transform.Translate (Vector2.right * -speed * Time.deltaTime);

	}


	public virtual void TakeDamage(){

	//	EnemyHP -= bulletBehavior.BulletDmg;
		is_damaged = true;

	}

	public virtual void DealDamage() {
		HeroVida.currentHealth -= DamageToHero;
		print (HeroVida.currentHealth);
		StartCoroutine(movements.invincibler());
		movements.invincibler ();

	}

	public virtual void OnCollisionEnter2D(Collision2D other) {
		if (movements.invincible == false) {
			if (other.gameObject.tag == "Player") {
		//		DealDamage ();



			}
		}
		if (other.gameObject.tag == "Bullet") {
			TakeDamage ();



		}
	}



	void Start () {
		Physics2D.IgnoreLayerCollision( 12, 10, true);
		Physics2D.IgnoreLayerCollision( 10, 12, true);
		CHchaser = GetComponentInChildren<Chaser> ();
		EnemyBody = GetComponent<Rigidbody2D> ();
		Vida = GetComponent<HeroVida> ();
		is_alive_enemy = !DeadEnemy;
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		OriginPoint = this.gameObject.transform.GetChild (0);
	}
	[Task]
	void Dead(){
		Destroy (gameObject, 2f);
	}

	// Update is called once per frame
	void Update () {
		
		distancePlayer = (Player.transform.position.x - transform.position.x);
//		print (CHchaser.ChasePlayer);
	//	print (is_moving);
		//print (is_alive_player);
		if (!DeadEnemy) {
			is_Idle = !is_moving;
			if (HeroVida.Vivo == false) {
				is_alive_player = false;

				is_damaged = false;
				is_on_chaseRange = false;
				is_on_attackRange = false;
				is_alert = false;
				//	Player = null;
			}
			if (is_alive_player) {

				//print("is_damaged " + is_damaged);



				//if (Input.GetButtonDown ("Jump")) {

				//	TakeDamage ();
				//print (EnemyHP);
				//}
				Debug.DrawRay (OriginPoint.position, dir * rangeB, Color.red);
				Debug.DrawRay (OriginPoint.position, dir * 0.5f, Color.green);
				if (CHchaser.ChasePlayer == true) {
					hitA = Physics2D.Raycast (OriginPoint.position, (Player.transform.position - OriginPoint.position));
					Debug.DrawRay (OriginPoint.position, (Player.transform.position - transform.position), Color.yellow);
					if (hitA == true) {

						if (hitA.collider.tag == "Player") {
							//		print ("achou o player");
							is_on_chaseRange = true;
							is_alert = true;

						} else if (is_alive_player == false) {
							is_on_chaseRange = false;

						} else {
							is_on_chaseRange = false;
						}
					}
				}

				hitB = Physics2D.Raycast (OriginPoint.position, dir, rangeB);
				if (hitB == true) {

					if (hitB.collider.tag == "Player") {
						//	print ("atacando o player");
						is_on_attackRange = true;
					} else {
						is_on_attackRange = false;	
					}

				} else if (!hitB ) {
					is_on_attackRange = false;
				}
			} else if (is_alive_player == false) {
				is_on_attackRange = false;
				is_on_chaseRange = false;
			//	is_on_attackRange = false;
				is_alert = false;
			}

			hitC = Physics2D.Raycast (OriginPoint.position, dir, rangeC);



			//if (Mathf.Abs (distancePlayer) <= 5f) {
			//	is_on_chaseRange = true;
			//	return;
			//} else {
			//	is_on_chaseRange = false;
			//	}
			//	if (Mathf.Abs (distancePlayer) <= distanceAttack) {
			//		is_on_attackRange = true;
			//	}  else {
			//		is_on_attackRange = false;
			//	}
		} else if (DeadEnemy == true) {
			is_on_attackRange = false;
			is_on_chaseRange = false;
		//	is_on_attackRange = false;
			is_alert = false;
			is_alive_enemy = false;
		}
	}


}
