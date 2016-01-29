using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour {

	public GameObject target;

	public float health = 5;
	public float attack = 2;
	public float moveSpeed = 2;

	public float interval = 3; // Attack interval
	private bool attackBool = false;

	private BoxCollider2D[] colliders;

	private BoxCollider2D colTrigger;

	public bool colliding = false;

	// Use this for initialization
	void Start () {
		colliders = GetComponents<BoxCollider2D> ();

		// Find the right collider from the enemy
		foreach (BoxCollider2D col in colliders) 
		{
			if (col.isTrigger) {
				colTrigger = col;
			}
		}
		StartCoroutine (attackWait());
	}

	// Update is called once per frame
	void Update () {

		if (!colliding)
			transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), target.transform.position, moveSpeed * Time.deltaTime);
		if (attackBool && colliding) {
			if (target != null && target.GetComponent<PlayerScript> ()) {

				// Reduce HP from the target
				target.GetComponent<PlayerScript> ().health -= attack;
				attackBool = false;
			}
		}
	}

	IEnumerator attackWait()
	{
		while (true) 
		{
			// Wait for X seconds for a new attack
			yield return new WaitForSeconds (interval);
			attackBool = true;
		}
	}
}
