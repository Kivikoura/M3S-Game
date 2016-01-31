using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillsScript : MonoBehaviour {


	[System.Serializable]
	public class Skill
	{
		public string name;
		public string description;
		public string type;
		public Sprite icon;
		public GameObject prefab;
		public float interval;
		public float cooldown;
		[HideInInspector] public bool castable = true; 

		public void useSkill(GameObject rotateObject, string caster)
		{
			if (castable) {
				GameObject go;
				go = Instantiate (prefab, rotateObject.transform.position, Quaternion.identity) as GameObject;
				if(name != "Zombie")
					go.transform.localEulerAngles = rotateObject.transform.eulerAngles;
				go.tag = caster;
			}
		}

	}
		

	public List<Skill> skills = new List<Skill>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
