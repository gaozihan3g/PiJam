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


}
