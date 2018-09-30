using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {
	public int playerCurrentHealth;
	public int playerMaxHealth = 50;

	private bool flashActive;
	public float flashLength;
	private float flashCounter;
	private SpriteRenderer playerSprite;
	public Transform respawnPoint;
//	public GameObject gameOverScreen;

	// Use this for initialization
	void Start () {
		playerCurrentHealth = playerMaxHealth;
		playerSprite = GetComponent<SpriteRenderer> ();


	}
	
	// Update is called once per frame
	void Update () {
		if (playerCurrentHealth <= 0) {
			print ("respawned");
			Respawn (gameObject);
			playerCurrentHealth = playerMaxHealth;
		} 


	

		if (flashActive) {

			//makes player flash when hit
			if (flashCounter > flashLength * 0.66f) {
				playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
			} else if (flashCounter > flashLength * 0.33f) {
				playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);

			} else if (flashCounter > 0f) {
				playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);

			} else {
				playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
				flashActive = false;
			}

			flashCounter -= Time.deltaTime;
		}
	}

	public void HurtPlayer(int damageToGive) {
		playerCurrentHealth -= damageToGive;
		flashActive = true;
		flashCounter = flashLength;
	}

	public void setMaxHealth() {
		playerCurrentHealth = playerMaxHealth;
	}

	//respawns player
	public void Respawn(GameObject player) {
		GameObject gameOverParent = GameObject.Find ("Canvas");
		GameObject gameOverScreen = gameOverParent.transform.Find ("GameOver").gameObject;
		gameOverScreen.SetActive (true);

		Vector3 respawn = GameObject.Find("RespawnPoint").transform.position;
		player.transform.position = respawn;

	}
}
