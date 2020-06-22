using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
	public float Speed;

	private Rigidbody rb;

	public LayerMask groundLayers;

	public float jumpForce = 7;

	public CapsuleCollider col;

	// Update is called once per frame

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		col = GetComponent<CapsuleCollider>();
	}

	void Update()
	{
		PlayerMovement();

		if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
		return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
	}
}
