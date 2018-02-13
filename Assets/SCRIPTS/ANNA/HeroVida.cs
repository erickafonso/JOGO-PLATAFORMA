using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeroVida : MonoBehaviour {

	public static bool Vivo = true;

	public static int startingHealth = 500;                            // The amount of health the player starts the game with.
	public static int currentHealth;                                   // The current health the player has.
	public Slider healthSlider;
	Gun GunScript;
	movements MovementsScript;

	private Animator anime;
	// Use this for initialization
	void Awake () {
		anime = GetComponent<Animator>();
		GunScript = GetComponent<Gun> ();
		MovementsScript = GetComponent<movements> ();
		//CheckAlive ();
		currentHealth = startingHealth; 
		healthSlider.maxValue = startingHealth;
		healthSlider.value = currentHealth;
	}
	
	// Update is called once per frame
	public void Update () {
		healthSlider.value = currentHealth;
		CheckAlive ();
		healthSlider.value = currentHealth;
	}
	public void CheckAlive(){

		if (currentHealth < 0)
			currentHealth = 0;
		if (currentHealth == 0) {
			Vivo = false;
			Viver ();
		}
	}

	void Viver (){
		if (Vivo == false) {
			
			anime.SetBool ("Dead", true);
		}
	}
		public void TakeDamage (int amount)
		{
			// Set the damaged flag so the screen will flash.
			//damaged = true;

			// Reduce the current health by the damage amount.
			currentHealth -= amount;

			// Set the health bar's value to the current health.
			healthSlider.value = currentHealth;

			// Play the hurt sound effect.
			//playerAudio.Play ();

			// If the player has lost all it's health and the death flag hasn't been set yet...
			//if(currentHealth <= 0 && !isDead)
			//{
				// ... it should die.
			//	Death ();
			//}
		}

		void Death ()
		{
			// Set the death flag so this function won't be called again.
			Vivo = false;

			// Turn off any remaining shooting effects.
			//playerShooting.DisableEffects ();

			// Tell the animator that the player is dead.
			anime.SetBool ("Dead" , true);

			// Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
			//playerAudio.clip = deathClip;
			//playerAudio.Play ();

			// Turn off the movement and shooting scripts.
			MovementsScript.enabled = false;
			GunScript.enabled = false;
		}       



}
