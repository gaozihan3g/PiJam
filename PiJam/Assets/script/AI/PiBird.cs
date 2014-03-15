using UnityEngine;
using System.Collections;

public class PiBird : MonoBehaviour {

	public GameObject pooPrefab;

	void Poo()
	{
		print("Poo");
		Instantiate(pooPrefab, transform.position, Quaternion.identity);
	}
}
