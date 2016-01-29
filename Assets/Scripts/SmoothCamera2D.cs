using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target1;
    public Transform target2;
    private Vector3 tetherVector;

	// Update is called once per frame
	void Update () 
	{
        tetherVector = (target1.position - target2.position) / 2;

        if (tetherVector != Vector3.zero)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(tetherVector);
            Vector3 delta = tetherVector - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

	}
}