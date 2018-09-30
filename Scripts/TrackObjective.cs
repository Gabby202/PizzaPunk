using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TrackObjective : MonoBehaviour {

	public static bool Key;
	public Text enemiesLeft;
	public Text keyStatus;
	public Text pizza1Status;
	public Text pizza2Status;
	public Text weaponStatus;
	public GameObject arrow;
	private bool arrowActive;
	public Transform arrowPosition;
	private bool pizza2Delivered;

	private GameObject[] EnemyCount;
	public int numberOfEnemies;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


		EnemyCount = GameObject.FindGameObjectsWithTag ("Enemy");
		numberOfEnemies = EnemyCount.Length;
		CheckEnemies ();

		if (!arrowActive && Key && SceneManager.GetActiveScene().name == "Level_One") {
			Instantiate (arrow, arrowPosition.position , Quaternion.identity);
			arrowActive = true;
		}


	}

/*	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "gate" && Key) {
			Destroy (other.gameObject);
		}
	}*/

	//functions for completing objectives
	public void KeyAqquired() {
	}

	public bool useKey() {
		return Key;
	}

	public void CheckEnemies() {
		enemiesLeft.text = "Enemies Left: " + numberOfEnemies;
	}

	public void Pizza1Delivered() {
		pizza1Status.text = "Pizza 1: Delivered";
	}

	public void Pizza2Delivered() {
		pizza2Status.text = "Pizza 2: Delivered";
		pizza2Delivered = true;
	}

	public void WeaponAcquired() {
		weaponStatus.text = "Weapon: Acquired";
	}

	public void KeyAcquired() {
		Key = true;
		keyStatus.text = "Key: Acquired";
	}



		

}
