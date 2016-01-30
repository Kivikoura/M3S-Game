using UnityEngine;
using System.Collections;

public class EnemyCollidingScript : MonoBehaviour {

	public EnemyScript enemyScript;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay2D(Collider2D col)
	{
		
		if(col.name == enemyScript.target.name)
			enemyScript.colliding = true;

		/*// If colliding gameobject is not the target. Change the enemys target to that collider.
		if (col.gameObject != enemyScript.target && col.tag == "Player")
			enemyScript.target = col.gameObject;*/
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Player")
			enemyScript.colliding = false;
	}
}
