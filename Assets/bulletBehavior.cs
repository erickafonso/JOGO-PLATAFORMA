using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour {

	public static int BulletDmg = 10;


	void Start () {
		Physics2D.IgnoreLayerCollision( 9, 10, true);
		Destroy (gameObject, 1.5f);
		Physics2D.IgnoreLayerCollision( 9, 9, true);
	}

	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D coll) {


		if (coll.gameObject.tag != "Bullet"  ) {
			//coll.gameObject.GetComponent<Enemy>();
			//DoDamage ();
			Destroy (gameObject);
		}
}

//	void OnBecameInvisible() {
//		Destroy(gameObject);
//	}
	//public void DoDamage(){
		//Enemy.EnemyLife -= BulletDmg;
		//print ("Enemy Life: " + Enemy.EnemyLife);
	//}

}