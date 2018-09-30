using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float movespeed;
	private Rigidbody2D myRigidBody;
	private bool moving;
	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;
	private Vector3 moveDirection;
	public float waitToReload;
	private bool reloading;
	private GameObject player;
	private Animator anim;
	private float moveX;
	private float moveY;
//	private float lastMoveX;
//	private float lastMoveY;
	Vector2 lastMove;
	private bool isMoving;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		myRigidBody = GetComponent<Rigidbody2D> ();

	//	timeBetweenMoveCounter = timeBetweenMove;
	//	timeToMoveCounter = timeToMove;

		timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeToMove * 1.25f);

	}
	
	// Update is called once per frame
	void Update () {

		//gets direction of object with rigid body velocity in order to animate it correctly
		if (myRigidBody.velocity.x > 0.5f) {
			isMoving = true;
			moveX = 1f;
			lastMove = new Vector2 (1f, 0f);
		} else if (myRigidBody.velocity.x < -0.5f) {
			isMoving = true;
			moveX = -1f;
			lastMove = new Vector2 (-1f, 0f);

		} else if (myRigidBody.velocity.y > 0.5f) {
			isMoving = true;
			moveY = 1f;
			lastMove = new Vector2 (0f, 1f);

		} else if(myRigidBody.velocity.y < -0.5f) {
			isMoving = true;
			moveY = -1f;
			lastMove = new Vector2 (0f, -1f);

		} else {
			moveX = 0f;
			moveY = 0f;
			isMoving = false;
		}

		//ai script to move random distances with random indervals and directions
		if (moving) {

			timeToMoveCounter -= Time.deltaTime;
			myRigidBody.velocity = moveDirection;

			if (timeToMoveCounter < 0f) {

				moving = false;
				//	timeBetweenMoveCounter = timeBetweenMove;
				timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);

			}

		} else {

			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidBody.velocity = Vector2.zero;
			if (timeBetweenMoveCounter < 0f) {
				moving = true;
		//		timeToMoveCounter = timeToMove;
				timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeToMove * 1.25f);

				moveDirection = new Vector3 (Random.Range(-1f, 1f) * movespeed, Random.Range(-1f, 1f) * movespeed, 0f);
			}
		
		}

		if (reloading) {
			waitToReload -= Time.deltaTime;
			if (waitToReload < 0) {
				
			}

		}

		//sets directions to animator
		anim.SetBool ("Moving", isMoving);
		anim.SetFloat ("MoveX", moveX);
		anim.SetFloat ("MoveY", moveY);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);


	}

	void OnCollisionEnter2D(Collision2D other) {
	/*	if (other.gameObject.tag == "Player") {
		//	reloading = true;
			player = other.gameObject;
			Respawn (player);
		} */

		if (other.gameObject.tag == "Boundry") {
			print ("in boundry");
		}

	}


}                                                                  
