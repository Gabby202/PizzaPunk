using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour {

	public int damageToGive;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//deals damage to player
	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerHealthManager> ().HurtPlayer(damageToGive);
		} 

	}
}
