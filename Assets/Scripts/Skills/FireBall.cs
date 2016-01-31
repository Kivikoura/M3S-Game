using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {
	public float speed = 2;
	public float damage = 5;
	public float lifeTime = 2.5f;

	public ParticleSystem particlePrefab;
	private ParticleSystem particle;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3(0f,speed,0) * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player" && col.name != this.tag || col.name == "Zombie(Clone)" && col.tag != this.tag)
		{
			if(col.GetComponent<EnemyScript>())
				col.GetComponent<EnemyScript> ().receiveDamage(damage);
			if(col.GetComponent<PlayerScript>())
				col.GetComponent<PlayerScript> ().receiveDamage(damage);
			
			particle = Instantiate(particlePrefab, col.transform.position, Quaternion.identity) as ParticleSystem;
			particle.transform.SetParent(transform.parent);
			Destroy(particle.gameObject, particle.startLifetime);
			Destroy(gameObject);

		}
	}
}
