using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour
{

    public AudioClip[] AudioClips;
    public AudioSource Source;

	// Use this for initialization
	void Start ()
	{
	    Source.clip = AudioClips[0];
        Source.Play();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}


}
