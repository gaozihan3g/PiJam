using UnityEngine;
using System.Collections;

public class Pee : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag=="Enemy")
		{
			other.gameObject.SendMessage("Die");
			Destroy(this.gameObject);
		}

//		if(other.gameObject.tag=="UpperPlatform")
//		{
//			Destroy(this.gameObject);
//		}
	}
}
