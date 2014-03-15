using UnityEngine;
using System.Collections;

public class LowerCollider : MonoBehaviour {


	void OnTriggerExit2D(Collider2D other)
	{
		//only functioning when falling down
		//to prevent when jumping down and the collided object belongs to the lower level, with out this collider it will go through
		if(other.gameObject.tag=="Player" && CharacterControl.Instance.vSpeed<=0)
		{
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("UpperPlatform"),false);
			//Debug.Log(Physics2D.GetIgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("UpperPlatform")));
		}
	}
}
