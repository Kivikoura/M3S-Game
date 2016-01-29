﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillsScript : MonoBehaviour {

	[System.Serializable]
	public class Skill
	{
		public string name;
		public string description;
		public float damage;
		public string type;
		public Sprite icon;
		public GameObject prefab;


	}


	public List<Skill> skills = new List<Skill>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
