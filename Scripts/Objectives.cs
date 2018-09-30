using UnityEngine;
using System.Collections;

public class Objectives : MonoBehaviour {

	private GameObject[] EnemyCount;
	public int numberOfEnemies;
	public GameObject pizza;
	private Vector3 position;
	public static bool complete1;
	public static bool complete2;
	public GameObject prefab;
	private Vector3 positionToSpawn;
	private bool arrowCreated;
	public static bool objectivesComplete;

	// Use this for initialization
	void Start () {
		if (objectivesComplete) {
			GameObject.FindGameObjectWithTag ("Finish").SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {

		positionToSpawn = new Vector3 (transform.position.x, transform.position.y, 0f);

		//stops enemies respawning if complete
		if (complete1) {
			Destroy(GameObject.FindGameObjectWithTag("Enemy"));
		}



		EnemyCount = GameObject.FindGameObjectsWithTag ("Enemy");

		numberOfEnemies = EnemyCount.Length;
//		print ("Enemies Left " + NumberOfEnemies);

		position = new Vector3(GameObject.FindGameObjectWithTag ("Player").transform.position.x + 1.5f, GameObject.FindGameObjectWithTag ("Player").transform.position.y , 0f);

		//creates pizza if all enemies killed
		if (!complete1) {
			if (numberOfEnemies == 0) {
				Instantiate (pizza, position, Quaternion.identity);
				complete1 = true;
			}
		}



	}

	public void EnemiesKilled() {

	}



}
