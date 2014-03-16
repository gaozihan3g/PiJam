using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public static AudioManager Instance;
	public AudioClip test;

	void Awake()
	{
		Instance = this;
	}



	public void PlayOneShot(AudioClip clip)
	{
		print ("play");
		audio.PlayOneShot(clip);
	}
}
