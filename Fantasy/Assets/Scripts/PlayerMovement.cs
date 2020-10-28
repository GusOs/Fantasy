using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	private Animator anim;
	private CharacterController controller;
	public float speed = 6.0f;
	public float runSpeed = 3.0f;
	public float turnSpeed = 60.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	private float w_sp = 0.0f;
	private float r_sp = 0.0f;
	private bool armed = true;
	public float lifePlayer = 100f;

	public float attackForce = 5.0f;

	// Start is called before the first frame update
	void Start()
    {
		anim = GetComponent<Animator>();
		controller = GetComponent<CharacterController>();
		w_sp = speed; //read walk speed
		r_sp = runSpeed; //read run speed
		runSpeed = 1;
	}

    // Update is called once per frame
    void Update()
    {
        checkAnimation();
		checkDead();

	}

    public void checkAnimation()
    {

		//------------------------------------------------------------------ MOVE

		if (Input.GetKey("w"))
		{
			anim.SetInteger("moving", 1);
			runSpeed = 1;
		}
		else
        {
			anim.SetInteger("moving", 0);
        }

		if (Input.GetKey("s"))
		{
			anim.SetInteger("moving", 12);
		}

		if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w"))
        {
			anim.SetInteger("moving", 3);
			runSpeed = 3;
        }



		//------------------------------------------------------------------ ARM

			if (Input.GetKeyUp("1"))
			{
				if (armed)
				{
					anim.SetBool("armed", true);
				}
				if (!armed)
				{
					anim.SetBool("armed", false);
					runSpeed = 1;
				}
				armed = !armed;
			}


		if (Input.GetKeyUp("2"))
		{
			if (armed)
			{
				anim.SetBool("arco", true);
			}
			if (!armed)
			{
				anim.SetBool("arco", false);
				runSpeed = 1;
			}
			armed = !armed;
		}


		//--------------------------------------------------------------------ATTACK

		if (Input.GetMouseButtonDown(0))
		{ // attack1
			anim.SetInteger("attack", 1);
		}
		else
        {
			anim.SetInteger("attack", 0);
        }


		//-------------------------------------------------------------------DEATH

		if(lifePlayer == 0)
        {
			anim.SetBool("death", true);
        }


		//-------------------------------------------------------------------TURNS

		var vert_modul = Mathf.Abs(Input.GetAxis("Vertical"));
		//Debug.Log(vert_modul);

		if ((Input.GetAxis("Horizontal") > 0.1f) && (vert_modul > 0.3f))
		{
			anim.SetLayerWeight(1, 1f);
			anim.SetBool("turn_right", true);
		}
		else if (vert_modul > 0.3f)
		{
			anim.SetBool("turn_right", false);
		}

		if ((Input.GetAxis("Horizontal") < -0.1f) && (vert_modul > 0.3f))
		{
			anim.SetLayerWeight(1, 1f);
			anim.SetBool("turn_left", true);
		}
		else if (vert_modul > 0.3f)
		{
			anim.SetBool("turn_left", false);
		}


		//--------------------------------------------------------------- MOVE SCENE

		if (controller.isGrounded)
		{
			moveDirection = transform.forward * Input.GetAxis("Vertical") * speed * runSpeed;

			if (vert_modul > 0.2f)
			{
				float turn = Input.GetAxis("Horizontal");
				transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	public void checkDead()
    {
		if(lifePlayer == 0)
        {
			anim.SetBool("death", true);
        }
    }
}
