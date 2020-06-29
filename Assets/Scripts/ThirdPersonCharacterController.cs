using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
	public float Speed;

	private Rigidbody rb;

	public LayerMask groundLayers;

	public float jumpForce = 7;

	private BoxCollider col;

	public int resourceAmount = 5;

	private float distToGround;

	// Update is called once per frame

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		col = GetComponent<BoxCollider>();
		distToGround = col.bounds.extents.y;
	}

	void Update()
	{
		PlayerMovement();

		if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}

		if (resourceAmount <= 0)
		{
			rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY;
			Debug.Log("You have lost all your gnomes! You Lose!");
		}
	}

	void PlayerMovement()
	{
		float hor = Input.GetAxis("Horizontal");
		float ver = Input.GetAxis("Vertical");
		Vector3 playerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;
		transform.Translate(playerMovement, Space.Self);
	}

	private bool IsGrounded()
	{
		//This line of code was originally for the players capsule collider however for a pltformer a box collider was a better idea
		//return Physics.CheckBox(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);

	}
}
