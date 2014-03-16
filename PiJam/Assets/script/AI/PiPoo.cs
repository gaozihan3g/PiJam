using UnityEngine;
using System.Collections;

public class PiPoo : MonoBehaviour {
	
	public AudioClip explosionSFX;
	public GameObject explosionPrefab;
	

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			AudioManager.Instance.PlayOneShot(explosionSFX);
			GameDirector.Instance.Die();
			Destroy(gameObject);
		}
	}

	void Die()
	{
		Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		AudioManager.Instance.PlayOneShot(explosionSFX);
		Destroy(gameObject);
	}
}
