using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	private int count;
	public GUIText winText;
	public GUIText countText;

	void Start()
	{
		count = 0;
		winText.text = "";
		SetCountText ();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidbody.AddForce(movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
		}
	}
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if (count >= 12) {
			winText.text = "You Win!";	
		}
	}

}