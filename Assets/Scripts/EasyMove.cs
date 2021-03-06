﻿using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

public class EasyMove : MonoBehaviour
{

    public ControlModes ControlMode;
	public float Speed = 0f;
    public Transform SpellDirectionIndicator;
	private float movex = 0f;
	private float movey = 0f;
    public float SpellX_1, SpellY_1, SpellX_2, SpellY_2;
    public float rot_1, rot_2;

    private float minLimit, maxLimit;
	private Animator animator;

	public AudioSource clip;

	public bool attackBool = true;

	private PlayerScript playerScript;

    public enum ControlModes
    {
        WASD,
        ARROWS,
        XB360_1,
        XB360_2
    };

	// Use this for initialization
	void Start ()
	{
	    minLimit = 0.2f;
	    maxLimit = 0.8f;

		playerScript = GetComponent<PlayerScript> ();
		animator = GetComponent<Animator> ();
		clip = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update ()
    {

	}

    bool CheckBorders(Vector3 moveTo)
    {
        bool isInside = true;
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position + moveTo);
        if (viewPos.x < minLimit || viewPos.x > maxLimit) isInside = false;
        if (viewPos.y < minLimit || viewPos.y > maxLimit) isInside = false;
        return isInside;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dir">1 moves to right, -1 moves to left</param>
    void MoveX(float dir)
    {
        movex = dir;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dir">1 moves to up, -1 moves to down</param>
    void MoveY(float dir)
    {
        movey = dir;
    }

    void SetTargetDirection(Vector3 dir)
    {
        SpellDirectionIndicator.localRotation = Quaternion.Euler(dir);
    }

    void UseSkill(int skillSlot)
    {
        
    }

	void FixedUpdate ()
	{
	    //Vector3 lookDir = new Vector3(Input.GetAxis("Horizontal_SpellDir"), Input.GetAxis("Vertical_SpellDir"));

        if (Input.GetAxis("Horizontal_SpellDir_1") != 0.0f && Input.GetAxis("Vertical_SpellDir_1") != 0.0f)
        {
            SpellX_1 = Input.GetAxis("Horizontal_SpellDir_1");
            SpellY_1 = Input.GetAxis("Vertical_SpellDir_1");

            rot_1 = Vector2.Angle(new Vector2(SpellX_1, SpellY_1), Vector2.up);
            Vector3 cross = Vector3.Cross(new Vector2(SpellX_1, SpellY_1), Vector2.up);

            if (cross.z > 0) rot_1 = 360 - rot_1;
        }

        if (Input.GetAxis("Horizontal_SpellDir_2") != 0.0f && Input.GetAxis("Vertical_SpellDir_2") != 0.0f)
        {
            SpellX_2 = Input.GetAxis("Horizontal_SpellDir_2");
            SpellY_2 = Input.GetAxis("Vertical_SpellDir_2");

            rot_2 = Vector2.Angle(new Vector2(SpellX_2, SpellY_2), Vector2.up);
            Vector3 cross = Vector3.Cross(new Vector2(SpellX_2, SpellY_2), Vector2.up);

            if (cross.z > 0) rot_2 = 360 - rot_2;
        }

        MoveX(0);
        MoveY(0);

        switch (ControlMode)
	    {
		case ControlModes.ARROWS:
			if (Input.GetKey (KeyCode.UpArrow))
				MoveY (1);
			if (Input.GetKey (KeyCode.DownArrow))
				MoveY (-1);
			if (Input.GetKey (KeyCode.RightArrow))
				MoveX (1);
			if (Input.GetKey (KeyCode.LeftArrow))
				MoveX (-1);
			if (Input.GetKey (KeyCode.V)) {
				if (attackBool) {
					useSkill (gameObject.GetComponent<PlayerScript> ().skillSlot1);
				}
			}
			if (Input.GetKey (KeyCode.B)) {
				if (attackBool) {
					useSkill (gameObject.GetComponent<PlayerScript> ().skillSlot2);
				}
			}
                break;
            case ControlModes.WASD:
                if (Input.GetKey(KeyCode.W)) MoveY(1);
                if (Input.GetKey(KeyCode.S)) MoveY(-1);
                if (Input.GetKey(KeyCode.D)) MoveX(1);
                if (Input.GetKey(KeyCode.A)) MoveX(-1);
                break;
			case ControlModes.XB360_1:
				MoveX (Input.GetAxis ("Horizontal_1"));
				MoveY (Input.GetAxis ("Vertical_1"));
				SpellDirectionIndicator.localRotation = Quaternion.Euler (0, 0, rot_1);
				if (Input.GetAxis ("RT_1") > 0.5f && attackBool) {
					useSkill (gameObject.GetComponent<PlayerScript> ().skillSlot1);
				}
				if (Input.GetAxis ("LT_1") > 0.5f && attackBool) {
					useSkill (gameObject.GetComponent<PlayerScript> ().skillSlot2);
				}
                if (Input.GetButton("RB_1") && attackBool)
                {
                    useSkill(gameObject.GetComponent<PlayerScript>().skillSlot3);
                }
                break;
            case ControlModes.XB360_2:
                MoveX(Input.GetAxis("Horizontal_2"));
                MoveY(Input.GetAxis("Vertical_2"));
                SpellDirectionIndicator.localRotation = Quaternion.Euler(0, 0, rot_2);
				if (Input.GetAxis ("RT_2") > 0.5f && attackBool) {
					useSkill (gameObject.GetComponent<PlayerScript> ().skillSlot1);
				}
				if (Input.GetAxis ("LT_2") > 0.5f && attackBool) {
					useSkill (gameObject.GetComponent<PlayerScript> ().skillSlot2);
				}
                if (Input.GetButton("RB_2") && attackBool)
                {
                    useSkill(gameObject.GetComponent<PlayerScript>().skillSlot3);
                }
                break;
            default:
                break;
	    }


		GetComponent<Rigidbody2D>().velocity = new Vector2 (movex * Speed, movey * Speed);
	

	
	}

	public void useSkill(SkillsScript.Skill skill)
	{
		skill.useSkill (SpellDirectionIndicator.gameObject, this.gameObject.name);
		if(skill.cooldown != 0){
			if (skill.castable) {
				StartCoroutine (attackCooldown (skill));
				if (SpellDirectionIndicator.localEulerAngles.z > 180)
					GetComponent<SpriteRenderer> ().flipX = true;
				else {
					GetComponent<SpriteRenderer> ().flipX = false;
				}
				//playerScript.voiceList [0].Play ();'
				clip.clip = playerScript.voiceList[0];
				clip.Play ();
				animator.SetBool ("isCasting", true);
			}
			
		}
		if(attackBool){
			StartCoroutine (attackInterval (skill.interval));
			if(skill.castable) animator.SetBool ("isCasting", true);
		}
	}

	// The wait time between attacks.
	IEnumerator attackInterval(float interval)
	{	
		attackBool = false;
		yield return new WaitForSeconds (interval);
		attackBool = true;
		animator.SetBool ("isCasting", false);
	}

	IEnumerator attackCooldown(SkillsScript.Skill skill)
	{
		skill.castable = false;
		yield return new WaitForSeconds (skill.cooldown);
		skill.castable = true;
		animator.SetBool ("isCasting", false);
			
	}

}