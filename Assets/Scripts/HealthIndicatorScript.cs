using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthIndicatorScript : MonoBehaviour {
	public GameObject player;

	private PlayerScript playerScript;
	private Text hpText;
	// Use this for initialization
	void Start () {
		playerScript = player.GetComponent<PlayerScript> ();
		hpText = GetComponent<Text> ();
		Debug.Log (hpText);
	}
	
	// Update is called once per frame
	void Update () {
		hpText.text = "Hp: " + playerScript.health;
	}
}
