using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target1;
    public Transform target2;
    private float targetDistance;
    private Vector3 midVector;

	// Update is called once per frame
	void Update ()
	{
        //targetDistance = Vector3.Distance(target1.position, target2.position); // Jos haluaa implementoida zoomaavan kameran, muutoin turha

        if (target1 != null && target2 != null) midVector = (target1.position + target2.position) / 2;
        else if (target1 != null) midVector = target1.position;
        else midVector = target2.position;

        transform.position = midVector + Vector3.back;

        //if (tetherVector != Vector3.zero)
        //{
        //    Vector3 point = GetComponent<Camera>().WorldToViewportPoint(tetherVector);
        //    Vector3 delta = tetherVector - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
        //    Vector3 destination = transform.position + delta;
        //    transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        //}
    }
}