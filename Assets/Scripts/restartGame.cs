using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class restartGame : MonoBehaviour {

	public float restartTime;
	bool restartNow = false;
	float resetTime;
	// Use this for initialization
	public playerHealth PH;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (restartNow && resetTime <= Time.time) {
			
			int i = Application.loadedLevel;
			Application.LoadLevel (i + 1);

			if (i == 5) {
				Application.LoadLevel (0);
				scoreAdd.scoreValue = 0;
			}
		}
			
	}
		
	public void nextLevel(){
		restartNow = true;
		resetTime = Time.time + restartTime;
	}
}
