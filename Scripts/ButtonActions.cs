using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ButtonActions : MonoBehaviour {


	//hides UI 
	void Update() {
		Destroy(GameObject.FindGameObjectWithTag("Canvas"));
	}

	//start Game button
	public void Load_Level_One() {
		Application.LoadLevel ("Level_One");
	}



	
}
