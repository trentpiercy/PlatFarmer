using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	Animator animator;

	private void Start()
	{
		animator = GetComponentInChildren<Animator>();
	}

	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		if (Mathf.Abs(horizontalMove) > 0)
		{
			animator.enabled = true;
		} else
		{
			animator.enabled = false;
		}

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
        }


        //if (Input.GetButtonDown("Crouch"))
        //{
        //	crouch = true;
        //} else if (Input.GetButtonUp("Crouch"))
        //{
        //	crouch = false;
        //}

    }

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
