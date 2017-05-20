using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	private int speed = 8;
	private Vector3 jump;
	private GameManager managerScript;
	private Rigidbody rb;

	public bool canGift;
	public bool isGrounded;
	public float jumpForce;
	public int numGifts;

	void Start () {

		rb = GetComponent<Rigidbody> ();
		jump = new Vector3 (0, 2f, 0);
		managerScript = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ();
	}

	void Update(){

		CheckGround ();
		CanGift ();
	}
	
	void FixedUpdate(){

		Move ();

		if(isGrounded == true){
			
			Jump ();
		}
	}

	void Move(){

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		rb.velocity = new Vector3 (moveHorizontal * speed, rb.velocity.y, moveVertical * speed);

	}

	void Jump(){

		if(Input.GetKeyDown(KeyCode.Space)){

			rb.AddForce (jump * jumpForce, ForceMode.Impulse);

		}
	}

	void CheckGround(){

		RaycastHit hit;

		if(Physics.Raycast(transform.position, Vector3.down * 0.1f, out hit, 1f)){

			isGrounded = true;
		}

		else
		{
			isGrounded = false;
		}
	}

	void CanGift(){

		numGifts = managerScript.numCollectables;

		if (numGifts > 0) {

			canGift = true;
		}
	}
}