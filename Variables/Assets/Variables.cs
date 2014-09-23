using UnityEngine;
using System.Collections;

public class Variables : MonoBehaviour {

	//Attach the GuiText object to our variable
	public GUIText textdisplay;

	//Our custom variables
	//Integers
	private int x;
	private int y;
	//Text
	private string myFistString;
	private string mySeccondString;
	//Floating point
	private float floatx;
	private float floatpi;
	//Boolean
	private bool myFirstBoolean;
	
	private int count = 0;
	// Use this for initialization
	// Any code we place in the start function will only run once when the game runs this script
	void Start () {

		x = 78;
		y = 34;

		floatx = 1.456f;
		floatpi = 3.14159265359f;

		myFistString = "Hello World";
		mySeccondString = "I like ";

		textdisplay.text = (floatx).ToString();

		textdisplay.text = myFirstFunction();

	}
	string myFirstFunction() {
		if (x > y) {
			return "X is greater than Y";
		}
		else {
			return "X is smaller than Y";
		}
	}

	void FixedUpdate () {
		/*
		if (Input.GetKey(KeyCode.W)){
			textdisplay.text = "Can you not press the W key"; 	
		}
		else if (Input.GetKey(KeyCode.S)){
			textdisplay.text = "Can you not press the S key"; 
		}
		else {
			textdisplay.text = "Please press the W or S key.";
		}*/
		
	}
	
	// Update is called once per frame
	void Update () {
		//Example of what void update does
		if (Input.GetKeyDown("space")){
			count = count + 1;
			textdisplay.text = (count).ToString();
		}

	}
}
