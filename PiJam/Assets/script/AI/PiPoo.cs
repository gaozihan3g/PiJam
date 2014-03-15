using UnityEngine;
using System.Collections;

public class PiPoo : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			print("GameOver");
		}
	}
}
