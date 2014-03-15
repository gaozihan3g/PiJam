using UnityEngine;
using System.Collections;

public class CameraMove : EndlessRunner {

	private Transform player;
	private float offset;

	void Awake ()
	{
		// Setting up the reference.
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	// Use this for initialization
	void Start () {
		offset= this.transform.position.x - player.position.x;
	
	}
	
	// Update is called once per frame
	void Update () {
		TrackPlayer ();
	}

	void TrackPlayer ()
	{
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = transform.position.x;
		float targetY = transform.position.y;

		

		// ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
		targetX = player.position.x+offset;

		
		// Set the camera's position to the target position with the same z component.
		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}
}
