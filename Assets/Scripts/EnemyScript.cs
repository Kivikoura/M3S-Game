using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour {

	public enum enemyCategory{Monster, Boss}

	public enemyCategory enemyCate;
	public GameObject target;

	public float health = 5;
	public float attack = 2;
	public float moveSpeed = 2;

	public float interval = 3; // Attack interval
	private bool attackBool = true;

	private BoxCollider2D colliders;

	public bool colliding = false;

	// Use this for initialization
	void Start () {
		colliders = GetComponent<BoxCollider2D> ();
		//StartCoroutine (moveRandomly());
		if (this.tag == "Player2")
			target = GameObject.Find ("Player1");
		if (this.tag == "Player1")
			target = GameObject.Find ("Player2");
	}

	// Update is called once per frame
	void Update () {

		// IF the enemy is not colliding with anything and has a target, move towards the target.
		if (!colliding && target != null)
			transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), target.transform.position, moveSpeed * Time.deltaTime);
			
		// If the enemy is colliding with something and is ready to attack.
		if (attackBool && colliding) {
			// if the enemy has a target and the target has playerscript, deal damage
			if (target != null && target.GetComponent<PlayerScript> ()) 
			{

				// Reduce HP from the target
				target.GetComponent<PlayerScript> ().receiveDamage(attack);
				StartCoroutine (attackInterval(interval));
			}
		}



			
	}

	// Possibly where the math happens.
	public void receiveDamage(float amount)
	{
		health -= amount;
		if (health <= 0)
			deathSequence ();
			
	}

	// Death animation needed.
	void deathSequence()
	{
		Destroy (gameObject);
	}

	// The wait time between attacks.
	IEnumerator attackInterval(float interval)
	{
		attackBool = false;
		yield return new WaitForSeconds (Random.Range(interval - 1, interval + 1));
		attackBool = true;
	}

}
