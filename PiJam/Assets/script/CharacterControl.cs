using UnityEngine;
using System.Collections;

public class CharacterControl : EndlessRunner
{
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;				// Condition for whether the player should jump.
	public bool jumpDown=false;

	[HideInInspector]
	public float vSpeed;    				//to know the character's vertical speed to see whether the character is falling

	[HideInInspector]   //dont show in inspector
	public bool haveCollision=true;


	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
	public float jumpForce = 1000f;			// Amount of force added when the player jumps.

	
	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;					// Reference to the player's animator component.

	public static CharacterControl Instance;


	//for guesture control
	[HideInInspector]
	public bool jumpGuesture=false;

	[HideInInspector]
	public bool jumpDownGuesture=false;

	[HideInInspector]
	public bool isDie=false;

	[HideInInspector]
	public bool shotGuesture=false;

	public Transform shotPos;
	public GameObject pee;
//	public float bulletSpeed;

	[HideInInspector]
	public bool isUpper=false;
	public AudioClip jumpSFX;

	// private bool isUpper=false;


	void Awake()
	{
		//singleton
		Instance = this;
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		anim = GetComponent<Animator>();
	}

	void Start()
	{

	}


	void Update()
	{	
		//do something every 5 frames
		if(Time.frameCount % 5 == 0) 
		{
			grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) || Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("UpperPlatform"));  
		}

		//Debug.Log (Physics2D.GetIgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("UpperPlatform")));
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.

		//to know whether the character is on the upper platform to use it in the gesture control(cannot call jumpdown function if is not there) 
		isUpper=Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("UpperPlatform"));
//		// If the jump button is pressed and the player is grounded then the player should jump.
//		if(Input.GetButtonDown("Jump") && grounded)
//		{
//			jump = true;
//		}
//		Debug.Log (Physics2D.GetIgnoreLayerCollision (LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("UpperPlatform")));
	}


	void FixedUpdate ()
	{
		vSpeed = rigidbody2D.velocity.y;
//		if(jumpDown && vSpeed<0)
//		{
//			jumpDown=false;
//		}
//
//		//is it falling down?
//		if(!grounded && vSpeed<0)
//		{
//			//use this is just not to give a value every update
//			if(!haveCollision)
//			{
//				//when it is falling, open the collision
//				Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("UpperPlatform"),false);
//				haveCollision=true;
//			}
//		}

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		rigidbody2D.velocity = new Vector2(maxSpeed,rigidbody2D.velocity.y);
//		if(rigidbody2D.velocity.x < maxSpeed)
//			// ... add a force to the player.
//			rigidbody2D.AddForce(Vector2.right * moveForce);
//
//		// If the player's horizontal velocity is greater than the maxSpeed...
//		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
//			// ... set the player's velocity to the maxSpeed in the x axis.
//			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
	}

	//[HideInInspector]
	//public bool jumpDownController=false;
	

	public void jumpDownFunction()
	{

		//when want to disable the collision, need to disconnect two colliders first! so need to jump a little bit
		//this.rigidbody2D.AddForce(Vector2.up*250);
		
		//StartCoroutine(notActiveCollision(0.1f));
		//but when this is falling down, the collider will be actived due to the code in update
		this.transform.position += Vector3.up*0.5f;

		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("UpperPlatform"));////////////////////////////////not functioning
		//no collision
		jumpDown = true;

	}

	//do not use this function now
//	IEnumerator notActiveCollision(float time)
//	{
//		jumpDown = true;
//		yield return new WaitForSeconds(time);
//		jumpDown = false;
//	}


	public void jumpFuction()
	{
		//when flying up, grounded also could be true so need another paramater to control
		if(grounded && vSpeed==0)
		{
			// Set the Jump animator trigger parameter.
//			anim.SetTrigger("Jump");
			
			// Play a random jump audio clip.
			//			int i = Random.Range(0, jumpClips.Length);
			//			AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);
			
			// Add a vertical force to the player.

			AudioManager.Instance.PlayOneShot(jumpSFX);

			rigidbody2D.AddForce(new Vector2(0f, jumpForce));


			//make suer player can jump on top of the upper platforms, can not put it in the on triggerEnter function
			//in the down collider scripts, because the calculation is too slow
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("UpperPlatform"));
			haveCollision=false;
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
		}
	}

	public void shot()
	{
		anim.SetTrigger ("Shot");
		GameObject a;
		a=(GameObject)Instantiate (pee,shotPos.position,Quaternion.identity);
//		a.rigidbody2D.velocity = Vector2.right * bulletSpeed;
	}

	public void Die()
	{
		//show UI
		isDie = true;
		Destroy (this.gameObject);
//		Time.timeScale = 0f;
	}

}
