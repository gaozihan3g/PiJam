using UnityEngine;
using System.Collections;

public class GuestureManager : MonoBehaviour {

	private bool pausing=false;



	void OnTap(TapGesture gesture) 
	{
		if(GameDirector.Instance.isPaused)
		{
			pausing=true;
			return;
		}
		if(pausing)
		{
			pausing=false;
			return;
		}
		//jump
		CharacterControl.Instance.jumpFuction ();
	}

	void OnSwipe(SwipeGesture gesture) 
	{
		// 大概的滑动方向
		FingerGestures.SwipeDirection direction = gesture.Direction;
		//Vector2 a = gesture.Direction;
		//Debug.Log (a);
		switch (gesture.Direction)
		{
		case FingerGestures.SwipeDirection.Down:
			if(CharacterControl.Instance.isUpper)
			{
				CharacterControl.Instance.jumpDownFunction();

			}
			break;
//		
//		case FingerGestures.SwipeDirection.Right:
//
//			CharacterControl.Instance.shot();
//			break;

		}

		
	}
}
