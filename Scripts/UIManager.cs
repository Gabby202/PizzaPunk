using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider healthBar;
	public Text healthText;
	private PlayerHealthManager playerHealth;
	private static bool UIExists;

	// Use this for initialization
	void Start () {
		if (!UIExists) {

			UIExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//healthbar update
		healthBar.maxValue = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthManager>().playerMaxHealth;
		healthBar.value = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthManager>().playerCurrentHealth;
		healthText.text = "HP: " + GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealthManager> ().playerCurrentHealth;
	}
}
