using UnityEngine;
using System.Collections;

public class TopCollider : MonoBehaviour {

	private bool haveCollision=false;

	void OnTriggerStay2D(Collider2D other)
	{
//		haveCollision = !Physics2D.GetIgnoreLayerCollision (LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("UpperPlatform"));
//		//when character is falling down and enter the trigger area, open the collision
//		if(!haveCollision && other.gameObject.tag=="Player" && CharacterControl.Instance.vSpeed<0 && !CharacterControl.Instance.jumpDown)
//		{
////			Debug.Log("111");
//			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("UpperPlatform"),false);
//			haveCollision=true;
//		}

		if(!CharacterControl.Instance.jumpDown)
		{
			if(!haveCollision && other.gameObject.tag=="Player" && CharacterControl.Instance.vSpeed<0)
			{
				Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("UpperPlatform"),false);
				haveCollision=true;
			}
		}
	}

//	void OnTriggerExit2D(Collider2D other)
//	{
//		haveCollision = false;
//		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("UpperPlatform"));
//	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(CharacterControl.Instance.jumpDown && CharacterControl.Instance.vSpeed<0f)
		{
			CharacterControl.Instance.jumpDown=false;
		}

//		Debug.Log (CharacterControl.Instance.jumpDown);
	}
}
