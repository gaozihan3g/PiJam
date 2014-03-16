using UnityEngine;
using System.Collections;

public class Pie : MonoBehaviour {

	public float speed;
	public float angularSpeed;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector3(speed, 0);
		Destroy(gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward, angularSpeed);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
//		AudioManager.Instance.PlayOneShot(splatSFX);
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
