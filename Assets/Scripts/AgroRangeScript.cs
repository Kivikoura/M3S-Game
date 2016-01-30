using UnityEngine;
using System.Collections;

public class AgroRangeScript : MonoBehaviour {
	public EnemyScript enemyScript;
	private CircleCollider2D agroRange;

	// Use this for initialization
	void Start () {
		agroRange = GetComponent<CircleCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyScript.target == null)
			agroRange.enabled = true;
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Player") 
		{
			enemyScript.target = col.gameObject;
			agroRange.enabled = false;
		}
	}
}
