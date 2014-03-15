using UnityEngine;
using System.Collections;

public class GameDirector : MonoBehaviour {

	private float currentGroundDis=0f;
	public float moveBackDis;
	public GameObject groundPrefab;
	public float groundLength;


	public static GameDirector Instance=new GameDirector();
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

	public void Die()
	{
		//disable camera follow
		GameObject.Find ("Main Camera").GetComponent<CameraMove>().enabled=false;
		//destroy character
		CharacterControl.Instance.Die ();
		//disable all generators
	}

	public void Restart()
	{
		Application.LoadLevel ("test1");
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
		scoreText.text = "score      " + point;
	}
	

	//UI
	
	void OnGUI() 
	{
		if(GUI.Button (new Rect (Screen.width-150, 50, 100, 100), pauseTexture,btnStyle))
		{
			Pause();
		}
		if(isPaused)
		{
			if (GUI.Button (new Rect (Screen.width/2-50, Screen.height/2-50, 100, 100), resumeTexture,btnStyle))// && CharacterControl.Instance.isDie)
			{
				Resume();
			}

			if (GUI.Button (new Rect (50, 50, 100, 100), homeTexture,btnStyle))// && CharacterControl.Instance.isDie)
			{
				Application.LoadLevel("StartMenu");
			}
			
		}
		
		if(CharacterControl.Instance.isDie)
		{
			if (GUI.Button (new Rect (Screen.width/2-50, Screen.height/2-50, 100, 100), restartTexture,btnStyle))
			{
				Restart();
			}
		}
		
	}


	


}
