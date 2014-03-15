using UnityEngine;
using System.Collections;

public class EndlessRunner : MonoBehaviour {

	private float moveBackDis=500f;

	public void OnEnable ()
	{
		GameDirector.moveBackEvent += OnMoveBack;
	}
	public void OnDisable()
	{
		GameDirector.moveBackEvent -= OnMoveBack;
	}

	public void OnMoveBack()
	{
		transform.position = new Vector3(transform.position.x-moveBackDis, transform.position.y, transform.position.z);
	}


}
