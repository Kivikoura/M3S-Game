using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

public class EasyMove : MonoBehaviour
{

    public ControlModes ControlMode;
	public float Speed = 0f;
    public Transform SpellDirectionIndicator;
	private float movex = 0f;
	private float movey = 0f;
    public float SpellX, SpellY;
    public Quaternion quat;

    private float minLimit, maxLimit;

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

	    SpellX = Input.GetAxis("Horizontal_SpellDir");
	    SpellY = Input.GetAxis("Vertical_SpellDir");

        quat = new Quaternion(SpellX, SpellY, 0, 0);

        MoveX(0);
        MoveY(0);

        switch (ControlMode)
	    {
	         case ControlModes.ARROWS:
                if (Input.GetKey(KeyCode.UpArrow)) MoveY(1);
                if (Input.GetKey(KeyCode.DownArrow)) MoveY(-1);
                if (Input.GetKey(KeyCode.RightArrow)) MoveX(1);
                if (Input.GetKey(KeyCode.LeftArrow)) MoveX(-1);
                break;
             case ControlModes.WASD:
                if (Input.GetKey(KeyCode.W)) MoveY(1);
                if (Input.GetKey(KeyCode.S)) MoveY(-1);
                if (Input.GetKey(KeyCode.D)) MoveX(1);
                if (Input.GetKey(KeyCode.A)) MoveX(-1);
                break;
             case ControlModes.XB360_1:
                MoveX(Input.GetAxis("Horizontal"));
                MoveY(Input.GetAxis("Vertical"));
	            SpellDirectionIndicator.localRotation = quat;
                SpellDirectionIndicator.eulerAngles.Set(0,0,SpellDirectionIndicator.eulerAngles.z/2);
                break;
            default:
                break;
	    }


		GetComponent<Rigidbody2D>().velocity = new Vector2 (movex * Speed, movey * Speed);
	}



}