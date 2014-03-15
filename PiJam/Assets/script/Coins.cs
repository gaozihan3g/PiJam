using UnityEngine;
using System.Collections;

public class Coins : EndlessRunner {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag=="Player")
		{
			GameDirector.Instance.ChangeScore();
			//music
			//particle
			Destroy(this.gameObject);
		}
	}
}
