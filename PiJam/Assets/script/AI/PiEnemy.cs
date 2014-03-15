using UnityEngine;
using System.Collections;

public class PiEnemy : MonoBehaviour {

	public float speed;
	public Sprite deadEnemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody2D.velocity = new Vector2(speed * Mathf.Sign(transform.localScale.x), 0f);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			print("GameOver");
		}
	}

	void Die()
	{
		print("Die");

	}
}
