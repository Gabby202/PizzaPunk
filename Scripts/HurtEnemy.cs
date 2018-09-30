using UnityEngine;
using System.Collections;

public class HurtEnemy : MonoBehaviour {

	public int damageToGive;
	public GameObject bloodParticle;
	public Transform hitPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other ) {

		//deals damage to enemy
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<EnemyHealthManager> ().HurtEnemy (damageToGive);
			//plays hit noise
			GetComponent<AudioSource> ().Play();
			Instantiate (bloodParticle, hitPoint.position, hitPoint.rotation);
		}
	}
}
