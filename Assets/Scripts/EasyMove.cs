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
    public float SpellX_1, SpellY_1, SpellX_2, SpellY_2;
    public float rot_1, rot_2;

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
                MoveX(Input.GetAxis("Horizontal_1"));
                MoveY(Input.GetAxis("Vertical_1"));
                SpellDirectionIndicator.localRotation = Quaternion.Euler(0,0,rot_1);
                break;
            case ControlModes.XB360_2:
                MoveX(Input.GetAxis("Horizontal_2"));
                MoveY(Input.GetAxis("Vertical_2"));
                SpellDirectionIndicator.localRotation = Quaternion.Euler(0, 0, rot_2);
                break;
            default:
                break;
	    }


		GetComponent<Rigidbody2D>().velocity = new Vector2 (movex * Speed, movey * Speed);
	}



}