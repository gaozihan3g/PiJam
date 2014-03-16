using UnityEngine;
using System.Collections;

public class BgGenerateChecker : MonoBehaviour {

	private bool once=true;

	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag=="Player" && once)
		{
			//Debug.Log("asdfasdfasf");
			GameObject.Find("GameDirector").SendMessage ("generateNewBg");
			once=false;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
			once = true;
	}
}
