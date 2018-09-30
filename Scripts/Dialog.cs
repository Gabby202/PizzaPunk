using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {

	public Text uiText;
	public GameObject dialogBox;
	public string[] strings;
	public float speed = 0.1f;
	private bool baguetteExists;

	int stringIndex = 0;
	int characterIndex = 0;

	public string dialogID;
	public string whoToTrigger;

	private  bool pizza1Delivered;
	private  bool pizza2Delivered;

	private bool startDialog;


	// Use this for initialization
	void Start () {
	}

	//counts down time 
	IEnumerator DisplayTimer() {
		while (1 == 1) {
			yield return new WaitForSeconds (speed);

			if (characterIndex > strings [stringIndex].Length) {
				continue;
			}

			uiText.text = strings [stringIndex].Substring (0, characterIndex);
			characterIndex++;
		}

	}
	
	// Update is called once per frame
	void Update () {

		//starts dialog when you press space
		if (Input.GetKeyDown (KeyCode.Space) && startDialog) {
			if (characterIndex < strings [stringIndex].Length) {
				characterIndex = strings [stringIndex].Length;
			} else if (stringIndex < strings.Length - 1) {

				stringIndex++;
				characterIndex = 0;
			} else {
				dialogBox.SetActive (false);
				//functions for what happens after cerain dialog
				if (!baguetteExists && dialogID == "pizza guy") {
					GameObject.Find ("PizzaGirl").GetComponent<Player>().ShowWeapoon ();
					GameObject.FindWithTag ("Cam2").GetComponent<TrackObjective> ().WeaponAcquired ();
					baguetteExists = true;
				}

				if (dialogID == "customer1" && !pizza1Delivered) {
					Destroy (GameObject.FindWithTag ("Player"));
					GameObject.FindWithTag ("Player").GetComponent<Player>().RemovePizza ();

					print ("Delivered");
					pizza1Delivered = true;
					GameObject.FindWithTag ("Cam2").GetComponent<TrackObjective> ().Pizza1Delivered ();
					GameObject.FindWithTag ("Cam2").GetComponent<TrackObjective> ().KeyAcquired ();

				}

				if (dialogID == "customer2" && !pizza2Delivered) {

					GameObject gameCompleteParent = GameObject.Find ("Canvas");
					GameObject gameCompleteScreen = gameCompleteParent.transform.Find ("GameComplete").gameObject;
					gameCompleteScreen.SetActive (true);

			/*		Destroy (GameObject.FindWithTag ("Player"));
					GameObject.FindWithTag ("Player").GetComponent<Player>().RemovePizza ();
					print ("Delivered");
					pizza2Delivered = true;
					GameObject.FindWithTag ("Cam2").GetComponent<TrackObjective> ().Pizza2Delivered ();
					GameObject.FindWithTag ("Player").GetComponent<FinishGame> ().GameComplete ();
					GameObject.FindWithTag ("Canvas").GetComponent<FinishGame> ().GameComplete ();
					GameObject.FindWithTag ("Cam2").GetComponent<FinishGame> ().GameComplete ();

					Destroy(GameObject.FindGameObjectWithTag("Canvas"));
					Destroy(GameObject.Find("Canvas")); */


				}
					
			}
		}


	}

	void OnTriggerEnter2D(Collider2D other) {

		//triggers dialog
		if (other.gameObject.name == whoToTrigger) {
			dialogBox.SetActive (true);
			startDialog = true;
			StartCoroutine (DisplayTimer ());
		} 

	}
}
