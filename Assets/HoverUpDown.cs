using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverUpDown : MonoBehaviour {

    public bool grounded;
    private float groundRadius = 0.25f;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();


    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        if (grounded)
        {
            posOffset = transform.position;
            tempPos = posOffset;
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

            transform.position = tempPos;
        }
    }
}