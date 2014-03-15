using UnityEngine;
using System.Collections;

public class BirdTrigger : MonoBehaviour {

	public GameObject bird;

	void OnTriggerEnter2D(Collider2D collider) {

		if (collider.tag == "Player")
		{
			bird.SendMessage("Poo");
		}

	}
}
