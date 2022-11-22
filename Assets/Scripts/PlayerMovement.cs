using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	public AudioSource footsteps;
	Animator animator;
	bool soundPlaying = false;

	private void Start()
	{
		animator = GetComponentInChildren<Animator>();
	}

	// Update is called once per frame
	void Update () {
		Debug.Log(Input.GetAxisRaw("Horizontal"));
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		if (Mathf.Abs(horizontalMove) > 0)
		{
			animator.enabled = true;
			if (!soundPlaying)
            {
				footsteps.Play();
				soundPlaying = true;

			}
		} else
		{
			animator.enabled = false;
			if (soundPlaying)
			{
				footsteps.Stop();
				soundPlaying = false;

			}
			//footsteps.Stop();
		}

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			if (soundPlaying)
            {
				footsteps.Stop();
				soundPlaying = false;
            }
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
