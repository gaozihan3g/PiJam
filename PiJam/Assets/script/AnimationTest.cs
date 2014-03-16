using UnityEngine;
using System.Collections;

public class AnimationTest : MonoBehaviour {

	Animator _animator;

	void Start()
	{
		_animator = GetComponent<Animator>();
	}

	void Jump()
	{
		_animator.SetTrigger("Jump");
	}

	void OnGUI()
	{
		if (GUI.Button(new Rect(10, 10, 10, 10), "Jump"))
			Jump();
	}

}
