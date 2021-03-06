using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class MicrophoneInputManager : MonoBehaviour {
	
    public float sensitivity = 100;
    public float loudness = 0;
	public float threshold;

	public float Value {
		get {
			return loudness / sensitivity;
		}
	}

	public float interval = 0.5f;
	private float timer = 0f;
	


    void Start() {
        audio.clip = Microphone.Start("Built-in Microphone", true, 10, 44100);
        audio.loop = true; // Set the AudioClip to loop
        audio.mute = true; // Mute the sound, we don't want the player to hear it
        while (!(Microphone.GetPosition("Built-in Microphone") > 0)){} // Wait until the recording has started
        audio.Play(); // Play the audio source!

		timer = Time.time;
    }

    void Update(){
		GetLoudness();

		CheckFire();
    }

	float GetAveragedVolume()
    { 
        float[] data = new float[16];
        float a = 0;
        audio.GetOutputData(data,0);
        foreach(float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a/16;
    }

	void GetLoudness()
	{
		loudness = GetAveragedVolume() * sensitivity;
	}

	void CheckFire()
	{
		if (Value > threshold)
		{
			Fire();
		}
	}

	void Fire()
	{
		if (CharacterControl.Instance == null)
			return;
		if (CheckCooldown())
		{
			CharacterControl.Instance.SendMessage("shot");
		}
	}

	bool CheckCooldown()
	{
		if (Time.time - timer > interval)
		{
			timer = Time.time;
			return true;
		}
		return false;
	}



}