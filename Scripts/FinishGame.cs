using UnityEngine;
using System.Collections;

public class FinishGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//finissh game screen
	public void GameComplete() {
		Destroy (gameObject);
		Application.LoadLevel ("Main_Menu");
	}
}
