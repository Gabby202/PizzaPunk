using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {
	public int CurrentHealth;
	private int MaxHealth = 30;

	// Use this for initialization
	void Start () {
		CurrentHealth = MaxHealth;
	}

	// Update is called once per frame
	void Update () {
		if (CurrentHealth <= 0) {
			Destroy (gameObject);
		}
	}

	//functions to modify the health of an enemy 
	public void HurtEnemy(int damageToGive) {
		CurrentHealth -= damageToGive;
	}

	public void setMaxHealth() {
		CurrentHealth = MaxHealth;
	}

}