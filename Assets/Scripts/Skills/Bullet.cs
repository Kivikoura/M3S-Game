using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float speed = 2;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3(0f,speed,0) * Time.deltaTime);
	}

	void Shoot()
	{

	}
}
