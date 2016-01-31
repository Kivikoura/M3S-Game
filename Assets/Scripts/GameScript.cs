using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {

	public GameObject panel;

	public Text winnerText;


	public void showWinner(string winner)
	{
		panel.SetActive (true);
		winnerText.text = winner + " WINS!";
	}
}
