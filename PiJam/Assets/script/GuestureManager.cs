using UnityEngine;
using System.Collections;

public class GuestureManager : MonoBehaviour {


	void OnTap(TapGesture gesture) 
	{
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

			CharacterControl.Instance.jumpDownFunction();

			//CharacterControl.Instance.jumpDownController=true;
			break;
		
		case FingerGestures.SwipeDirection.Right:

			CharacterControl.Instance.shot();
			break;

		}

		
	}
}
