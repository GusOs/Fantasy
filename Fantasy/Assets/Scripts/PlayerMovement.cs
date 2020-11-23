using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	// Variable del animator
	private Animator anim;

	//variable del charactercontroller
	private CharacterController controller;

	//Variable de velocidad
	public float speed = 6.0f;

	// Variable velocidad movimientos
	public float runSpeed = 3.0f;

	//Variable de velocidad al girar
	public float turnSpeed = 60.0f;

	//Variable de gravedad
	public float gravity = 20.0f;

	//Variable de dirección
	private Vector3 moveDirection = Vector3.zero;

	//Variable que hace referencia a la velocidad
	private float w_sp = 0.0f;

	//Variable que hace referencia a la velocidad de movimientos
	private float r_sp = 0.0f;

	// Variable si está armado
	private bool armed = true;

	//Audio envainar arma
	public Sound unsheathe;

	//Audio desenvainar arma
	public Sound sheathe;

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
        CheckAnimation();
	}

    public void CheckAnimation()
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
				AudioManager.Instance.PlaySound(unsheathe);
			}
			if (!armed)
			{
				anim.SetBool("armed", false);
				AudioManager.Instance.PlaySound(sheathe);
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
}
