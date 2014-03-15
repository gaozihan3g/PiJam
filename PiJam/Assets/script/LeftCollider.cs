using UnityEngine;
using System.Collections;

public class LeftCollider : MonoBehaviour {
	private float height=0.3f;
	private bool firstTime=true;
	Vector3 moveDirection = new Vector3 (1, 1, 0);
	
	//when Main character is falling down and hit the upper platform's collider from side, move up character a little bit
	//use this to prevent character to be stucked
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag=="Player" && CharacterControl.Instance.vSpeed<=0 && firstTime)
		{
			Debug.Log("moved a little bit");

		
			other.gameObject.transform.position+=moveDirection * height;

			firstTime=false;

		}

//		if(other.gameObject.tag=="Player" && CharacterControl.Instance.vSpeed<=0)
//		{
//			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("UpperPlatform"));
//		}
	}


}
