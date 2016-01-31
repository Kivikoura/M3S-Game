using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour
{

    public AudioClip[] AudioClips;
    public AudioSource Source;
    private int current;
    public bool next;

	// Use this for initialization
	void Start ()
	{
	    next = false;
	    current = 0;
	    Source.clip = AudioClips[current];
        Source.Play();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (next && Source.time > 23.99)
	    {
	        Source.clip = AudioClips[++current];
            Source.Play();
	        next = false;
	    }
	}

    void NextVerse()
    {
        next = true;
    }


}
