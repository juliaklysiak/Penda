using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour {
    private CharacterController controller;
    private float speed = 10.0f;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    private bool IsDeath = false;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
        if (IsDeath)
            return;

    
        moveVector = Vector3.zero;

        if(controller.isGrounded)
        { verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // x- right and left
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        // z- forward and backward
        moveVector.z = speed;
        //Y - up and down
        moveVector.y = verticalVelocity;
        
        controller.Move (moveVector * Time.deltaTime);
	}
    public void SetSpeed(float modifier)
    {
        speed = 10.0f + modifier;
    }
    private void OnTriggerEnter (Collider other)
    {
        Destroy(other.gameObject) ; 
             Death ();
    }
    private void Death()
    {
        Debug.Log("kill");
        IsDeath = true;
        GetComponent<score>().OnDeath();
    }
}
