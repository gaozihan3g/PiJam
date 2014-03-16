using UnityEngine;
using System.Collections;

public class PiBird : MonoBehaviour {

	public GameObject pooPrefab;
	public AudioClip dropSFX;

	void Poo()
	{
		print("Poo");
		AudioManager.Instance.PlayOneShot(dropSFX);
		Instantiate(pooPrefab, transform.position, Quaternion.identity);
	}
}
