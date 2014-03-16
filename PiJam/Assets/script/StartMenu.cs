using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public Texture downTexture;
	public AudioClip SFX;

	void OnMouseDown() 
	{
//		GameObject.GetComponent<"SpriteRenderer">.Sprite=downTexture;
		this.guiTexture.texture = downTexture;
			
	}

	void OnMouseUp()
	{
		StartCoroutine(StartGame());
	}

	IEnumerator StartGame()
	{
		AudioManager.Instance.PlayOneShot(SFX);
		yield return new WaitForSeconds(3f);
		Application.LoadLevel(1);
	}
}
