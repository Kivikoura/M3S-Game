using UnityEngine;
using System.Collections;

public class EasyMove : MonoBehaviour
{

    public int ControlMode = 0;
	public float Speed = 0f;
	private float movex = 0f;
	private float movey = 0f;

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

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (getKeyCode(dir.LEFT)))
			movex = -1;
		else if (Input.GetKey (getKeyCode(dir.RIGHT)))
			movex = 1;
		else
			movex = 0;
		if (Input.GetKey (getKeyCode(dir.UP)))
			movey = 1;
		else if (Input.GetKey (getKeyCode(dir.DOWN)))
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

	void FixedUpdate ()
	{

		GetComponent<Rigidbody2D>().velocity = new Vector2 (movex * Speed, movey * Speed);
	}



}