using UnityEngine;
using System.Collections;

public class LoadNewArea : MonoBehaviour {

	public string levelToLoad;
	public GameObject prefab;
	public string exitPoint;
	private PlayerController player;
	public string exitId;
	// Use this for initialization

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		player = FindObjectOfType<PlayerController> ();

	}

	void OnTriggerEnter2D(Collider2D other) {

		//decides position of spawn in new scene
		if (other.gameObject.tag == "Player") {
			DontDestroyOnLoad (GameObject.FindGameObjectWithTag("Player"));
			Application.LoadLevel (levelToLoad);
			player.startPoint = exitPoint;
			print ("new startpoint is " + player.startPoint);
		}

	}
}
