﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

	public float health = 20;
	public float attack = 2;
	public float facingRotateSpeed = 5;
	public bool attackBool = true;

	public SkillsScript.Skill skillSlot1;

	public GameObject facing;

	public SkillsScript skillScript;

	// Use this for initialization
	void Start () {
		skillSlot1 = skillScript.skills [0];
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
		{
			if (skillSlot1.name != "" && attackBool)
			{
				skillSlot1.useSkill (facing);
				StartCoroutine (attackInterval());
			}
		}
		if (health <= 0)
			Destroy (gameObject);
	}

	IEnumerator attackInterval()
	{
		attackBool = false;
		yield return new WaitForSeconds (0.5f);
		attackBool = true;
	}

}
