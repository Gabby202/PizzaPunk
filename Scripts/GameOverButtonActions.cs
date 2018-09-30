using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverButtonActions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	//button functions for game over and checkpoint screens

	public void Retry() {
	//	SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	//	GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealthManager> ().gameOverScreen.SetActive(false);
		GameObject gameOverParent = GameObject.Find ("Canvas");
		GameObject gameOverScreen = gameOverParent.transform.Find ("GameOver").gameObject;
		gameOverScreen.SetActive (false);
	}

	public void Restart() {
		print ("clicked");
		GameObject gameCompleteParent = GameObject.Find ("Canvas");
		GameObject gameCompleteScreen = gameCompleteParent.transform.Find ("GameComplete").gameObject;
		gameCompleteScreen.SetActive (false);
		Application.LoadLevel ("Main_Menu");
	}
}
