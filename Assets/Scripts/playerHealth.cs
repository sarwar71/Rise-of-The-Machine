using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour {

	int x;

	public float fullHealth;
	public GameObject deathFx;
	public AudioClip playerHurt;

	public restartGame theGameManager;

	public gameOver theGameOver;

	float currentHealth;

	playerController controlMovement;
	AudioSource playerAS;
	public AudioClip playerDeathSound;

	//HUD variables
	public Slider healthSlider;
	public Image damageScreen;
	public Text gameOverScreen;
	public Text levelComplete;
	public Text winGame;

	bool damaged = false;
	Color damagedColour = new Color (1f, 0f, 0f, 0.5f);
	float smoothColour = 5f;

	// Use this for initialization
	void Start () {
		currentHealth = fullHealth;
		controlMovement = GetComponent<playerController> ();

		//HUD initilization
		healthSlider.maxValue = fullHealth;
		healthSlider.value = fullHealth;

		damaged = false;

		playerAS = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (damaged) {
			damageScreen.color = damagedColour;
		} else {
			damageScreen.color = Color.Lerp (damageScreen.color, Color.clear, smoothColour * Time.deltaTime);
		}
		damaged = false;
	}

	public void addDamage(float damage){
		if (damage <= 0)
			return;
		
		currentHealth -= damage;

		//playerAS.clip = playerHurt;
		//playerAS.Play ();

		playerAS.PlayOneShot(playerHurt);

		healthSlider.value = currentHealth;
		damaged = true;

		if (currentHealth <= 0) {
			makeDead ();
		}
	}

	public void addHealth(float health){
		currentHealth += health;
		if (currentHealth > fullHealth)
			currentHealth = fullHealth;

		healthSlider.value = currentHealth;
	}

	public void makeDead(){
		Instantiate (deathFx, transform.position, transform.rotation);
		Destroy(gameObject);
		AudioSource.PlayClipAtPoint (playerDeathSound, transform.position);
		damageScreen.color = damagedColour;

		Animator gameOverAnimator = gameOverScreen.GetComponent<Animator> ();
		gameOverAnimator.SetTrigger ("gameOver");
		//theGameManager.restartTheGame ();

		theGameOver.restartTheGame ();
	}
		
	public void completeLevel(){
		Destroy (gameObject);
		theGameManager.nextLevel ();

		Animator levelCompleteGameAnimator = levelComplete.GetComponent<Animator> ();
		levelCompleteGameAnimator.SetTrigger ("gameOver");

	}
}
