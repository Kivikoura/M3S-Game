using UnityEngine;
using System.Collections;

public class EnemyCollidingScript : MonoBehaviour {

	private EnemyScript enemyScript;

	// Use this for initialization
	void Start () {
		enemyScript = GetComponent<EnemyScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Player")
			enemyScript.colliding = true;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Player")
			enemyScript.colliding = false;
	}
}
