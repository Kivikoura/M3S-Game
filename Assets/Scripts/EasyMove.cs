using UnityEngine;
using System.Collections;

public class EasyMove : MonoBehaviour
{

    public int ControlMode = 0;
	public float Speed = 0f;
	private float movex = 0f;
	private float movey = 0f;

    private float minLimit, maxLimit;

    private enum dir
    {
        UP,
        RIGHT,
        DOWN,
        LEFT
    }

	// Use this for initialization
	void Start ()
	{
	    minLimit = 0.2f;
	    maxLimit = 0.8f;
	}

	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKey (getKeyCode(dir.LEFT)) && CheckBorders(Vector3.left))
			movex = -1;
		else if (Input.GetKey (getKeyCode(dir.RIGHT)) && CheckBorders(Vector3.right))
			movex = 1;
		else
			movex = 0;
		if (Input.GetKey (getKeyCode(dir.UP)) && CheckBorders(Vector3.up))
			movey = 1;
		else if (Input.GetKey (getKeyCode(dir.DOWN)) && CheckBorders(Vector3.down))
			movey = -1;
		else
			movey = 0;
	}

    KeyCode getKeyCode(dir direction)
    {
        switch (ControlMode)
        {
            case 0:
                if (direction == dir.UP) return KeyCode.W;
                if (direction == dir.RIGHT) return KeyCode.D;
                if (direction == dir.DOWN) return KeyCode.S;
                if (direction == dir.LEFT) return KeyCode.A;
                break;
            case 1:
                if (direction == dir.UP) return KeyCode.UpArrow;
                if (direction == dir.RIGHT) return KeyCode.RightArrow;
                if (direction == dir.DOWN) return KeyCode.DownArrow;
                if (direction == dir.LEFT) return KeyCode.LeftArrow;
                break;
            default:
                if (direction == dir.UP) return KeyCode.W;
                if (direction == dir.RIGHT) return KeyCode.D;
                if (direction == dir.DOWN) return KeyCode.S;
                if (direction == dir.LEFT) return KeyCode.A;
                break;
        }
        return KeyCode.None;
    }

    bool CheckBorders(Vector3 moveTo)
    {
        bool isInside = true;
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position + moveTo);
        if (viewPos.x < minLimit || viewPos.x > maxLimit) isInside = false;
        if (viewPos.y < minLimit || viewPos.y > maxLimit) isInside = false;
        return isInside;
    }

	void FixedUpdate ()
	{

		GetComponent<Rigidbody2D>().velocity = new Vector2 (movex * Speed, movey * Speed);
	}



}