using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float health = 20;
	public float attack = 2;
	public float facingRotateSpeed = 5;
	public bool attackBool = true; // Check if we can attack

	public SkillsScript.Skill skillSlot1;
	public SkillsScript.Skill skillSlot2;

	public SkillsScript skillScript;
	public GameObject facing;


	// Use this for initialization
	void Start () {
		skillSlot1 = skillScript.skills [0]; // Testi vain
		skillSlot2 = skillScript.skills [1]; // Testi vain
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
			if (skillSlot1.name != "" && attackBool) {
				
				skillSlot1.useSkill (facing);
				StartCoroutine (attackInterval(skillSlot1.interval));
			}
		}
		if (Input.GetKey (KeyCode.V)) 
		{
			if (skillSlot2.name != "" && attackBool) {
				skillSlot2.useSkill (facing);
				StartCoroutine (attackInterval (skillSlot2.interval));
			}
		}

		if (health <= 0)
			Destroy (gameObject);

		if (attackBool == false)
		{
			// Don't allow the player to move.
		}
	}

	IEnumerator attackInterval(float interval)
	{
		attackBool = false;
		yield return new WaitForSeconds (interval);
		attackBool = true;
	}

}
