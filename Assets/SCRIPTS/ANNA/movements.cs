using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movements : MonoBehaviour {
	
		[HideInInspector]
		public bool facingRight = true;			// For determining which way the player is currently facing.
		[HideInInspector]
		public bool jump = false;				// Condition for whether the player should jump.

		public float moveForce = 0.035f;			// Amount of force added to move the player left and right.
		public float maxSpeed = 1f;				// The fastest the player can travel in the x axis.

		public float jumpForce = 200f;			// Amount of force added when the player jumps.

		private Transform groundCheck;			// A position marking where to check if the player is grounded.
		private bool grounded = false;			// Whether or not the player is grounded.
		private Animator anim;					// Reference to the player's animator component.
		public HeroVida Vida;
		public static bool invincible = false;
		public static bool knockback = false;
//	static CapsuleCollider2D PlayerColider;
	//static SpriteRenderer PlayerColor;
	GameObject Enemies;
	SpriteRenderer m_SpriteRenderer;
	//The Color to be assigned to the Renderer’s Material
	Color m_NewColor;
		void Awake()
		{
			// Setting up references.
			groundCheck = transform.Find("groundCheck");
			anim = GetComponent<Animator>();
			Vida = GetComponent<HeroVida>();
		//PlayerColider = GetComponent<CapsuleCollider2D> ();
		//PlayerColor = GetComponent<SpriteRenderer> ();
		//Fetch the SpriteRenderer from the GameObject
		m_SpriteRenderer = GetComponent<SpriteRenderer>();
		}


		 void Update()
		{
		if (HeroVida.Vivo == true) {
			// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
			grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));  

			// If the jump button is pressed and the player is grounded then the player should jump.
			if (Input.GetButtonDown ("Jump") && grounded)
				jump = true;

			if (grounded) {
				anim.SetBool ("Jump", false);
			} else {
				anim.SetBool ("Jump", true);
			}

		} 
			


		}


		void FixedUpdate ()
	{


		if (HeroVida.Vivo == true) {
			
				

				// Cache the horizontal input.
				float h = Input.GetAxis ("Horizontal");

				//GetComponent<Rigidbody2D> ().velocity = new Vector2 (h * moveForce, GetComponent<Rigidbody2D> ().velocity.y);
				// The Speed animator parameter is set to the absolute value of the horizontal input.
				anim.SetFloat ("Speed", Mathf.Abs (h));
			
			
				//if (h > 0) {
					GetComponent<Rigidbody2D>().transform.Translate (new Vector2(moveForce*h, 0f));

				//}
				//if (h < 0) {
				//	GetComponent<Rigidbody2D>().velocity = (new Vector2(-moveForce, 0f));

				//}

				// If the input is moving the player right and the player is facing left...
				if (h > 0 && !facingRight)
				// ... flip the player.
				Flip ();
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (h < 0 && facingRight)
				// ... flip the player.
				Flip ();

				// If the player should jump...
				if (jump) {
					// Set the Jump animator trigger parameter.
					anim.SetTrigger ("Jump");

					// Play a random jump audio clip.
				

					// Add a vertical force to the player.
					GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, jumpForce));

					// Make sure the player can't jump again until the jump conditions from Update are satisfied.
					jump = false;
					//}
				}
			}
		}



		void Flip ()
		{
			// Switch the way the player is labelled as facing.
			facingRight = !facingRight;

			// Multiply the player's x local scale by -1.
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
	}

	void isAlive()
	{
		if (HeroVida.currentHealth == 0)
			anim.SetTrigger ("Dead");
	}
	IEnumerator OnCollisionEnter2D(Collision2D c)
	{
		// force is how forcefully we will push the player away from the enemy.
		float force = 100f;


	

		// If the object we hit is the enemy
			if (c.gameObject.tag == "Enemy") {
			StartCoroutine(TakeDamage());
			TakeDamage ();
				// Calculate Angle Between the collision point and the player
				//Vector3 dir = c.contacts[0].point - transform.position;
				// We then get the opposite (-Vector3) and normalize it
				Vector2 direction = (transform.position - c.transform.position).normalized;
				// And finally we add force in the direction of dir and multiply it by force. 
				// This will push back the player
			//transform.Translate( Vector2.right * 1.0f);

			this.GetComponent<Rigidbody2D> ().AddForce (direction * force);
			Physics2D.IgnoreCollision (c.gameObject.GetComponent<Collider2D> (), GetComponent<Collider2D> (), true);
			yield return new WaitForSeconds (2);
			//print ("2 segundos depois");
			m_SpriteRenderer.color = Color.white;
			Physics2D.IgnoreCollision (c.gameObject.GetComponent<Collider2D> (), GetComponent<Collider2D> (), false);

		}
				//Physics2D.IgnoreCollision( this.GetComponent<Collider2D>(),  c.gameObject.GetComponent<Collider2D>(), invincible);


		}
	


	 
		
	public static IEnumerator invincibler()
	{
		invincible = true;

		yield return new WaitForSeconds(1);
		invincible = false;
	}
IEnumerator TakeDamage(){
	m_SpriteRenderer.color = Color.red;
	yield return new WaitForSeconds (0.06f);
	//print ("2 segundos depois");
	m_SpriteRenderer.color = Color.white;
}
		
}



