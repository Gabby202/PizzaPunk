using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PizzaController : MonoBehaviour {

	public GameObject arrow;
//	private Vector3 position;
	public Transform arrowPosition;
	public Transform arrowPosition2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//displays arrow to next objective when pick up pizza

	void OnTriggerEnter2D(Collider2D hit) {

		if (hit.CompareTag ("Player") && SceneManager.GetActiveScene().name == "Level_One") {
			Destroy(GameObject.FindGameObjectWithTag("Player"));
	//		position = new Vector3 (21.46f, -10.11f, 0f);
			Instantiate (arrow, arrowPosition.position, Quaternion.identity);

		}
		if(hit.CompareTag("Weapon") && SceneManager.GetActiveScene().name == "Level_One")  {
			Destroy(GameObject.FindGameObjectWithTag("Player"));
	//		position = new Vector3 (21.46f, -10.11f, 0f);
			Instantiate (arrow, arrowPosition.position, Quaternion.identity);
		}

		if(hit.CompareTag("Player") && SceneManager.GetActiveScene().name == "Level_Two")  {
			Destroy(GameObject.FindGameObjectWithTag("Player"));
			//		position = new Vector3 (21.46f, -10.11f, 0f);
			Instantiate (arrow, arrowPosition2.position, Quaternion.identity);
		}

		if(hit.CompareTag("Weapon") && SceneManager.GetActiveScene().name == "Level_Two")  {
			Destroy(GameObject.FindGameObjectWithTag("Player"));
			//		position = new Vector3 (21.46f, -10.11f, 0f);
			Instantiate (arrow, arrowPosition2.position, Quaternion.identity);
		}
	}
}
