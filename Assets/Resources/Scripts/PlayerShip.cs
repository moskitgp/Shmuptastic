using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour {


	public float speed = 25f;
	public int health = 3;
	public GameObject bullet;
	public int fireRate = 10;

	GameObject launcherL,launcherR;
	Rigidbody2D rb;
	int delay;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		launcherL = transform.Find ("LauncherL").gameObject;
		launcherR = transform.Find ("LauncherR").gameObject;
	}

	void Update () {
		if (Input.GetKey(KeyCode.Space) && delay>fireRate)
			Shoot ();
		delay++;
	}
	
	void FixedUpdate () {

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		/* Vector3 movement = new Vector3 (moveHorizontal, moveVertical,0.0f);
		rb.AddForce (movement * speed * Time.deltaTime); */ 		// Old, slugish movement method

		Vector2 movement = new Vector3 (moveHorizontal, moveVertical);
		rb.velocity = movement * speed * Time.deltaTime; 			// much better movement method and feeling
	}

	public void Damage(){
		health--;
		if(health == 0){
			Destroy(gameObject);
		}
	}

	void Shoot(){
		delay = 0;
		Instantiate (bullet, launcherL.transform.position, Quaternion.identity);
		Instantiate (bullet, launcherR.transform.position, Quaternion.identity);
	}
}
