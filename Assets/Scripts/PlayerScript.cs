using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float health = 20;
	public float attack = 2;
	public float facingRotateSpeed = 5;

	public SkillsScript.Skill skillSlot1;

	public GameObject facing;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.Z))
		{
			if(facing != null)
				facing.transform.Rotate (Vector3.forward * -facingRotateSpeed);
			
		}
		if (Input.GetKey (KeyCode.X))
		{
			if(facing != null)
				facing.transform.Rotate (Vector3.forward * facingRotateSpeed);
		}
		if (Input.GetKey (KeyCode.C))
			

		if (health <= 0)
			Destroy (gameObject);
	}

}
