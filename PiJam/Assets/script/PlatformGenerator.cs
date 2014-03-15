using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	public GameObject[] obj;
	private int objLength;
	public float maxTime=1;
	public float minTime=0.5f;

	// Use this for initialization
	void Start () 
	{
		objLength = obj.Length;
		spawn ();
	}
	

	public void spawn()
	{
		int i = Random.Range(0, objLength);

		Instantiate (obj[i], transform.position,Quaternion.identity);

		Invoke ("spawn",Random.Range(minTime,maxTime));
	}

}

//int i = Random.Range(0, jumpClips.Length);
//AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);
//		               