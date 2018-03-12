using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShips : MonoBehaviour {

	public float horizontalSpeed;
	public float verticalSpeed; 

	public bool canShoot;
	public float fireRate;
	public int health;
	public GameObject bullet;

	private Rigidbody2D rb;
	private GameObject launcherL,launcherR;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		//launcherL = transform.Find ("LauncherL").gameObject;
		//launcherR = transform.Find ("LauncherR").gameObject;

		if (canShoot) {
			InvokeRepeating ("Shoot", fireRate,fireRate);
		}
	}
	
	void Update() {
		rb.velocity = new Vector2 (horizontalSpeed, verticalSpeed * -1f);
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Player") {
			collision.gameObject.GetComponent<PlayerShip>().Damage();
			Die();
		}
		
	}

	void Die(){
		Destroy(gameObject);
	}

	public void Damage(){
		health--;
		if (health == 0)
			Die();
	}
	void Shoot (){
		Instantiate (bullet, launcherL.transform.position, Quaternion.identity);
		Instantiate (bullet, launcherR.transform.position, Quaternion.identity);
	}
}
