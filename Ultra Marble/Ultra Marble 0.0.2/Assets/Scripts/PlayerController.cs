using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody Player_rb;
    public float inputStrength;

    // Use this for initialization
    void Start () {
        Player_rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        // Retrieve Inputs
        float horizontalAxis = Input.GetAxis ("Horizontal");
        float verticalAxis = Input.GetAxis ("Vertical");

        // Assign camaera to variable
        var camera = Camera.main;

        // Retrieve vectors relative to camera
        var forward = camera.transform.forward;
        var right = camera.transform.right;

        // Project forward and right vectors onto the horizontal plane
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // Calculate the direction we wish to move
        var desiredMoveDirection = forward * verticalAxis + right * horizontalAxis;

        Player_rb.AddForce (desiredMoveDirection * inputStrength);

	}
}
