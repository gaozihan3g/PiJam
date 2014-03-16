using UnityEngine;
using System.Collections;

public class PiPoo : MonoBehaviour {

	public Sprite explosion;
	public AudioClip explosionSFX;
	private SpriteRenderer _spriteRenderer;

	void Start()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}


	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			_spriteRenderer.sprite = explosion;
			AudioManager.Instance.PlayOneShot(explosionSFX);
			GameDirector.Instance.Die();
		}
	}
}
