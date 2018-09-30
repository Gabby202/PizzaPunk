using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Vector3 vectorForObject;
	public GameObject prefab;
	public GameObject prefabWithoutPizza;
	public GameObject weapon;
	public GameObject equipedWeapon;
	private static bool Key;

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag ("Player").GetComponent<CameraController> ();
	}
	
	// Update is called once per frame
	void Update () {

		//removes duplicate players
		vectorForObject = new Vector3 (transform.position.x, transform.position.y, 0f);
		if (!GameObject.Find ("PizzaGirl")) {
			Destroy (GameObject.Find ("Pizza"));

		}

		Key = GameObject.FindGameObjectWithTag ("Cam2").GetComponent<TrackObjective> ().useKey ();
	}


	//objective checks

	void OnTriggerEnter2D(Collider2D hit) {
		if (hit.CompareTag ("Pizza")) {
			print ("hit");
			//vectorForObject = hit.transform.position;
			Instantiate (prefab, vectorForObject, Quaternion.identity);
			hit.gameObject.SetActive (false);

		}

		if(hit.CompareTag("Weapon")) {
			Destroy(hit.gameObject);
			equipedWeapon.SetActive(true);
		}

	
		if (hit.gameObject.name == "gate" && Key) {
			Destroy (hit.gameObject);
		}
	
	}

	public void ShowWeapoon() {
		vectorForObject = new Vector3 (transform.position.x + 2f, transform.position.y, 0f);
		Instantiate (weapon, vectorForObject, Quaternion.identity);
	}

	public void RemovePizza() {
		Instantiate (prefabWithoutPizza, vectorForObject, Quaternion.identity);

	}

	public void OpenGate() {
		Destroy(GameObject.Find("Gate"));
	}

}
