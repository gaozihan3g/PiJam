using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public Texture downTexture;

	void OnMouseDown() 
	{
//		GameObject.GetComponent<"SpriteRenderer">.Sprite=downTexture;
		this.guiTexture.texture = downTexture;
			
	}

	void OnMouseUp()
	{
		Application.LoadLevel(1);
	}
}
