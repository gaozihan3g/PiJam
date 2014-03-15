using UnityEngine;
using System.Collections;

public class PiEnemy : EndlessRunner {

	public float speed;
	public Sprite deadEnemy;
	private SpriteRenderer _spriteRenderer;
	public SpriteRenderer[] allRenderers;

	// Use this for initialization
	void Start () {
		allRenderers = GetComponentsInChildren<SpriteRenderer>();
		_spriteRenderer = transform.Find("body").GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody2D.velocity = new Vector2(speed * Mathf.Sign(transform.localScale.x), 0f);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			GameDirector.Instance.Die();
			print("GameOver");
		}
	}

	void Die()
	{
		print("Die");
		//disable all sprite renderers
		foreach (SpriteRenderer sr in allRenderers)
			sr.enabled = false;

		//set sprite
		_spriteRenderer.enabled = true; 
		_spriteRenderer.sprite = deadEnemy;
		//remove colliders
		Collider2D[] co = GetComponents<Collider2D>();
		for (int i = 0; i < co.Length; i++)
			Destroy(co[i]);

		//add physics effects
		rigidbody2D.fixedAngle = false;
		rigidbody2D.AddTorque(-5000f);
		Destroy(gameObject, 2f);

	}

	void OnGUI()
	{
		if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button"))
			Die();

	}

//	void OnGUI()
//	{
//		if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button"))
//			Die();
//	}
}
