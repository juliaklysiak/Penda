using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playermove : MonoBehaviour {
    private CharacterController controller;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    public float speed = 10.0f;
    public int healthpoints;

    public Text healthText;

    private bool IsDeath = false;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        switch(PlayerPrefs.GetInt("CharacterSelected"))
        {
            case 0:
                speed = 10f;
                healthpoints = 3;
                break;
            case 1:
                speed = 5f;
                healthpoints = 1;
                break;
            case 2:
                speed = 15f;
                healthpoints = 5;
                break;
        }

	}
	
	// Update is called once per frame
	void Update () {
        if (IsDeath)
            return;

        healthText.text = "Lives: " + healthpoints;
        moveVector = Vector3.zero;

        // x- right and left
        if ((Input.GetKeyDown(KeyCode.A) || (Input.GetMouseButtonDown(0)) && Input.mousePosition.x < Screen.width / 2))
        {
            moveVector.x = transform.position.x - 100f;
        }
        else if ((Input.GetKeyDown(KeyCode.D) || (Input.GetMouseButtonDown(0)) && Input.mousePosition.x > Screen.width / 2))

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
        speed = speed + modifier;
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.transform.gameObject.tag == "Obstacle")
        {
            Destroy(other.gameObject);
            healthpoints--;

            if (healthpoints<=0)
            Death();
        }
        if (other.transform.gameObject.tag == "doubleObstacle")
        {
            Destroy(other.gameObject);
            healthpoints -= 2; ;
            if (healthpoints <= 0)
                Death();
        }
        if (other.transform.gameObject.tag == "gold")
        {
            // slowly
            Destroy(other.transform.gameObject);
            speed = speed/1.5f;

        }
        if (other.transform.gameObject.tag == "silver")
        {
            // add lifes
            Destroy(other.transform.gameObject);
            healthpoints++;

        }
    }
    private void Death()
    {
        Debug.Log("kill");
        IsDeath = true;
        GetComponent<score>().OnDeath();
    }
}
