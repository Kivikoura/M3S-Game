using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

	public float health = 20;
	public float attack = 2;
	public float facingRotateSpeed = 5;
	public bool attackBool = true; // Check if we can attack

	public SkillsScript.Skill skillSlot1;
	public SkillsScript.Skill skillSlot2;
	public SkillsScript.Skill skillSlot3;

	public SkillsScript skillScript;
	public GameObject facing;
	private Animator animator;
	private AnimationState state;
	private AnimatorStateInfo state1;

	public GameScript gameScript;

	public List<AudioClip> voiceList = new List<AudioClip> ();
	private AudioSource aSource;

	private Rigidbody2D rigidbody;


	// Use this for initialization
	void Start () {
		skillSlot1 = skillScript.skills [0]; // Testi vain
		skillSlot2 = skillScript.skills [1]; // Testi vain
		skillSlot3 = skillScript.skills [2]; // VIELKI TESTI

		rigidbody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		aSource = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

		if (rigidbody.velocity.x > 0.1f)
			GetComponent<SpriteRenderer> ().flipX = true;
		if (rigidbody.velocity.x < -0.1f)
			GetComponent<SpriteRenderer> ().flipX = false;
	
		if (rigidbody.velocity.x > 0.1f || rigidbody.velocity.x < -0.1f)
			animator.SetFloat ("isWalking", 1);
		else if (rigidbody.velocity.y > 0.1 || rigidbody.velocity.y < 0)
			animator.SetFloat ("isWalking", 1);
		else
			animator.SetFloat ("isWalking", 0);
		
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
		/*if (Input.GetKey (KeyCode.C))
		{
			if (skillSlot1.name != "" && attackBool) {
				
				skillSlot1.useSkill (facing,  this.gameObject.name);
				StartCoroutine (attackInterval(skillSlot1.interval));
			}
		}
		if (Input.GetKey (KeyCode.V)) 
		{
			if (skillSlot2.name != "" && attackBool) {
				skillSlot2.useSkill (facing,  this.gameObject.name);
				StartCoroutine (attackInterval (skillSlot2.interval));
			}
		}*/

		if (health <= 0)
			Destroy (gameObject);

		if (attackBool == false)
		{
			// Don't allow the player to move.
		}
	}
	// Possibly where the math happens.
	public void receiveDamage(float amount)
	{
		health -= amount;
		aSource.clip = voiceList [1];
		aSource.Play ();
		if (health <= 0)
			deathSequence ();

	}

	// Death animation needed.
	void deathSequence()
	{
		if(this.name == "Player1")
			gameScript.showWinner ("Player 2");
		if(this.name == "Player2")
			gameScript.showWinner ("Player 1");
		Destroy (gameObject);
	}

	IEnumerator attackInterval(float interval)
	{
		attackBool = false;
		yield return new WaitForSeconds (interval);
		attackBool = true;
	}

}
