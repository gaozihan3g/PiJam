using UnityEngine;
using System.Collections;

public class Coins : EndlessRunner {

	public AudioClip collectSFX;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag=="Player")
		{
			GameDirector.Instance.ChangeScore();
			AudioManager.Instance.PlayOneShot(collectSFX);
			//music
			//particle
			Destroy(this.gameObject);
		}
	}
}
