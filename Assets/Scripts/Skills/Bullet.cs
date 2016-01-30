using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {

	public float speed = 2;
	public float damage;

	// Use this for initialization
	void Start () {
		Object.Destroy (gameObject, 10f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (new Vector3(0f,speed,0) * Time.deltaTime);
	}

	void Shoot()
	{

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Enemy") {
			if (col.GetComponent<EnemyScript> ())
				col.GetComponent<EnemyScript> ().health -= damage;

			Destroy (gameObject);
		}			


	}


}
