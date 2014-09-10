using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {

	public float gravity = .1f;
	public float speed = .1f;
	public float acceleration = .5f;
	public float jumpHeight = .4f;

	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;

	private PlayerPhysics playerPhysics;

	// Use this for initialization
	void Start () {
		playerPhysics = GetComponent<PlayerPhysics>();
	}

	// Update is called once per frame
	void Update () {

		if (playerPhysics.moveStop) {
			targetSpeed = 0;
			currentSpeed = 0;
		}

		targetSpeed = Input.GetAxisRaw ("Horizontal") * speed;
		currentSpeed = IncrementTowards (currentSpeed, targetSpeed, acceleration);


		if (playerPhysics.grounded) {
			amountToMove.y = 0;	
			//jump
				if (Input.GetButtonDown("Jump")){
				amountToMove.y = jumpHeight;
				}
		}

		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		playerPhysics.Move(amountToMove);
	}

	void OnTriggerEnter2D(Collider2D other) {
		//CODE NOT WORKING
	}

	private float IncrementTowards(float n, float target, float a){
		if (n == target) {
						return n;
				} else {
			float dir = Mathf.Sign (target - n);
			n +=a * Time.deltaTime * dir;
			       return (dir == Mathf.Sign(target-n))? n: target;
				}
	}

}
