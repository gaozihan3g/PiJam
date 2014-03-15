﻿using UnityEngine;
using System.Collections;

public class GroundGenerateChecker : MonoBehaviour {
	private bool once=true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag=="Player" && once)
		{
			//Debug.Log("asdfasdfasf");
			GameObject.Find("GameDirector").SendMessage ("generateNewGround");
			once=false;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
						once = true;
	}
}
