using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float runSpeed = 5;
	[SerializeField] private float jumpForce = 10;
	public Transform groundCheck;
	public Image life;

	private bool facingRight = true;
	private bool jump = false;
	private bool grounded = true;
	private Animator _animator;
	private Rigidbody2D _rigidbody;
	private ControlMessage CM;
	private AudioSource jumpSound;


	// Start is called before the first frame update
	void Start () 
	{
		_animator = GetComponent<Animator> ();
		_rigidbody = GetComponent<Rigidbody2D> ();
		jumpSound = GetComponent<AudioSource>();
		_rigidbody.freezeRotation = true;

		// Get ControlMessage GameObject for the life system method
		GameObject controlMessageObject = GameObject.FindWithTag ("ControlMessage");
		if (controlMessageObject != null) 
		{
			CM = controlMessageObject.GetComponent<ControlMessage> ();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{	
		// Capture Jump Button 
		if (Input.GetButtonDown("Jump") && grounded)
		{
			jump = true;
		}

		_animator.SetBool("Grounded", grounded);
	}
	
	// FixedUpdate is called once per physics update (default 100 times per second)
	void FixedUpdate()
	{
		// Checks the player is grounded
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));		

		// Move
		float horizontalInput = Input.GetAxis("Horizontal");
		_rigidbody.velocity = new Vector2(horizontalInput * runSpeed, _rigidbody.velocity.y);

		if(horizontalInput != 0)
        {
			_animator.SetTrigger("Run");
        }
        else
        {
			_animator.SetTrigger("Idle");
        }   
		
		// Jump
		if (jump)
		{
			jumpSound.Play();
			_rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
			jump = false;
		}

		// Facing Right
		if (horizontalInput > 0 && !facingRight)
		{
			Flip();
		}
		else if (horizontalInput < 0 && facingRight)
		{
			Flip();
		}
	}

	// Method to fix the player position
	public void Flip()
	{
		facingRight = !facingRight;
		transform.Rotate(0, 180f, 0);
	}

	// Life System
	[System.Obsolete]
	public void SubtractsLife()
	{
		life.fillAmount-=0.1f;
		if (life.fillAmount <= 0) 
		{
			CM.GameOver();
			Destroy(gameObject);
		}
	}	
}
