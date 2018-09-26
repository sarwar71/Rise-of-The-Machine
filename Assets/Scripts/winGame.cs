using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winGame : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (scoreAdd.scoreValue >=80 && scoreAdd.scoreValue <=100) {
				playerHealth playerWins = other.gameObject.GetComponent<playerHealth> ();
				playerWins.completeLevel ();
		
			}

			else if (scoreAdd.scoreValue >= 160 && scoreAdd.scoreValue <= 200) {
				playerHealth playerWins = other.gameObject.GetComponent<playerHealth> ();
				playerWins.completeLevel ();
			}

			else if (scoreAdd.scoreValue >= 260 && scoreAdd.scoreValue <= 320) {
				playerHealth playerWins = other.gameObject.GetComponent<playerHealth> ();
				playerWins.completeLevel ();
			}
			else if (scoreAdd.scoreValue >= 360 && scoreAdd.scoreValue <= 420) {
				playerHealth playerWins = other.gameObject.GetComponent<playerHealth> ();
				playerWins.completeLevel ();
			}
			else if (scoreAdd.scoreValue >= 460 && scoreAdd.scoreValue <= 520) {
				playerHealth playerWins = other.gameObject.GetComponent<playerHealth> ();
				playerWins.completeLevel ();
			}
		}
	}
}
