using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour {

	public GameObject target;
	public float speed = 2;
	public float interval = 3; // Attack interval
	private bool attackBool = false;

	private BoxCollider2D[] colliders;

	private BoxCollider2D colTrigger;

	public bool colliding = false;

	// Use this for initialization
	void Start () {
		colliders = GetComponents<BoxCollider2D> ();

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
			transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), target.transform.position, speed * Time.deltaTime);
		if (attackBool && colliding) {
			if (target.GetComponent<PlayerScript> ()) {
				Debug.Log ("Test");
				target.GetComponent<PlayerScript> ().health -= 1;
				attackBool = false;
			}
		}
	}

	IEnumerator attackWait()
	{
		while (true) 
		{
			yield return new WaitForSeconds (interval);
			attackBool = true;
		}
	}
}
