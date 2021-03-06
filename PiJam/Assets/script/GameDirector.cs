﻿using UnityEngine;
using System.Collections;

public class GameDirector : MonoBehaviour {


	private float currentGroundDis=0f;
	public float moveBackDis;
	public GameObject groundPrefab;
	public float groundLength;
	public float bgLength;

	public GameObject bgPrefab;
 
	private float currentBgDis=0f;


	public static GameDirector Instance;
	public delegate void moveBack();
	public static event moveBack moveBackEvent;


	//variable for ui
	public Texture pauseTexture;
	public Texture resumeTexture;
	public Texture restartTexture;
	public Texture homeTexture;
	
	[HideInInspector]
	public bool isPaused=false;
	
	
	public GUIStyle btnStyle;

	public int point;
	public GUIText scoreText;
	public AudioClip gameOverSFX;
	public AudioClip btnSFX;

	// Use this for initialization
	void Start () {
		Instance = this;
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void startMoveBack()
	{
		//Debug.Log (currentGroundDis);
		moveBackEvent ();
		currentGroundDis -= moveBackDis;
		currentBgDis -= moveBackDis;
	}

	public void generateNewGround()
	{
		currentGroundDis += groundLength;
		Instantiate(groundPrefab, new Vector3(currentGroundDis, 0, 0), Quaternion.identity);
		if (currentGroundDis>=moveBackDis)
		{
			startMoveBack();
		}
	}


	public void generateNewBg()
	{
		currentBgDis += bgLength;
		Instantiate(bgPrefab, new Vector3(currentBgDis, 5.45f, 2f), Quaternion.identity);
	}

	public void Die()
	{
		audio.Stop();
		AudioManager.Instance.PlayOneShot(gameOverSFX);
		//disable camera follow
		GameObject.Find ("Main Camera").GetComponent<CameraMove>().enabled=false;
		//destroy character
		CharacterControl.Instance.Die ();
		//disable all generators
	}

	public void Restart()
	{
		Application.LoadLevel (1);
	}
	
	public void Pause()
	{
		isPaused = true;
		Time.timeScale = 0;
	}
	
	public void Resume()
	{
		isPaused = false;
		Time.timeScale = 1;
	}

	public void ChangeScore()
	{
		point++;
		scoreText.text = "score    " + point;
	}
	

	//UI
	
	void OnGUI() 
	{
		if(GUI.Button (new Rect (Screen.width-100, 40, 30, 30), pauseTexture,btnStyle))
		{
			AudioManager.Instance.PlayOneShot(btnSFX);
			Pause();
		}
		if(isPaused)
		{
			if (GUI.Button (new Rect (Screen.width/2-50, Screen.height/2-50, 100, 100), resumeTexture,btnStyle))// && CharacterControl.Instance.isDie)
			{
				AudioManager.Instance.PlayOneShot(btnSFX);
				Resume();
			}

			if (GUI.Button (new Rect (70, 40, 35, 35), homeTexture,btnStyle))// && CharacterControl.Instance.isDie)
			{
				AudioManager.Instance.PlayOneShot(btnSFX);
				Time.timeScale = 1;
				Application.LoadLevel("StartMenu");
			}
			
		}
		
		if(CharacterControl.Instance.isDie)
		{
			if (GUI.Button (new Rect (Screen.width/2-50, Screen.height/2-50, 100, 100), restartTexture,btnStyle))
			{
				AudioManager.Instance.PlayOneShot(btnSFX);
				Restart();
			}
		}
		
	}


	


}
