using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour {

	public GameObject target;

	public float health = 5;
	public float attack = 2;
	public float moveSpeed = 2;

	public float agroRange;

	public float interval = 3; // Attack interval
	private bool attackBool = false;

	private BoxCollider2D colliders;

	public bool colliding = false;

	// Use this for initialization
	void Start () {
		colliders = GetComponent<BoxCollider2D> ();

		StartCoroutine (attackWait());
	}

	// Update is called once per frame
	void Update () {

		if (!colliding && target != null)
			transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), target.transform.position, moveSpeed * Time.deltaTime);
		if (attackBool && colliding) {
			if (target != null && target.GetComponent<PlayerScript> ()) {

				// Reduce HP from the target
				target.GetComponent<PlayerScript> ().health -= attack;
				attackBool = false;
			}
		}
			
	}

	public void receiveDamage(float amount)
	{
		health -= amount;
		if (health <= 0)
			deathSequence ();
			
	}

	void deathSequence()
	{
		Destroy (gameObject);
	}

	IEnumerator attackWait()
	{
		while (true) 
		{
			// Wait for X seconds for a new attack
			yield return new WaitForSeconds (Random.Range(interval - 1, interval + 1));
			attackBool = true;
		}
	}
}
