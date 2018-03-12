using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Rigidbody2D rb;
	private int direction = 1;

	public int speed = 5;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	public void ChangeDirection(){
		direction *= -1;
	}

	void FixedUpdate (){
		rb.velocity = new Vector2 (0,speed * direction);
	}

	void OnTriggerEnter2D(Collider2D col)
	{	
		if (direction == 1) {
			if (col.gameObject.tag == "EnemyShip") {
				col.gameObject.GetComponent<EnemyShips> ().Damage ();
				Destroy (gameObject);
			}
		}
		else{
			if(col.gameObject.tag == "Player") {
				col.gameObject.GetComponent<PlayerShip> ().Damage ();
				Destroy (gameObject);
			}
		}
	}

}