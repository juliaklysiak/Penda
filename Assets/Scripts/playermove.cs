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

        // x- right and left
        if(Input.GetKeyDown(KeyCode.A))
        {
            moveVector.x = transform.position.x - 100f;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            moveVector.x = transform.position.x + 100f;
        }
        // z- forward and backward
        moveVector.z = speed;
        //Y - up and down
        moveVector.y = 0;
        
        controller.Move (moveVector * Time.deltaTime);
	}
    public void SetSpeed(float modifier)
    {
        speed = 10.0f + modifier;
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.transform.gameObject.tag == "Obstacle")
        {
            Destroy(other.gameObject);
            Death();
        }
        if (other.transform.gameObject.tag == "doubleObstacle")
        {
            Destroy(other.gameObject);
            Death();
        }
        if (other.transform.gameObject.tag == "gold")
        {
         // slowly
        }
        if (other.transform.gameObject.tag == "silver")
        {
            // add lifes
        }
    }
    private void Death()
    {
        Debug.Log("kill");
        IsDeath = true;
        GetComponent<score>().OnDeath();
    }
}
