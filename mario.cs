using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mario : MonoBehaviour {
	
	public int playerSpeed = 10;
	private bool facingRight = false;
	public int playerJumpPower = 1250;
	private float moveX;
	public bool isGrounded;
	

	void Update () {
		PlayerMove ();
	}
	void PlayerMove(){
	
		moveX = Input.GetAxis("Horizontal");
		if (Input.GetButtonDown("Jump") && isGrounded == true){
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower);	
			isGrounded = false;		
		}
		
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}
	
	void OnCollisionEnter2D (Collision2D col){
		Debug.Log ("Palyer has coollided with " + col.collider.name);
		if (col.gameObject.tag == "ground"){
			isGrounded = true;
		}
	}
}
