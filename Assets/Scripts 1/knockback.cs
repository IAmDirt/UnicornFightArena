﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockback : MonoBehaviour
{

    public float maxSpeed = 8f;
    public float Speed = 1f;

    public float KnockBackForce;

    private Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    //go forward
    void FixedUpdate()
    {
        if (Speed <= -10)
        {
            Speed = 0f;
        }

        Vector2 velocity = new Vector3(0, Speed);
        velocity = transform.rotation * velocity;

        rb2d.AddForce(velocity);

        if (Speed < maxSpeed)

            Speed += 0.04f;
    }

        void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.gameObject.tag == "enemy")
            {

            }
            else
            {
                Vector2 collisionPoint = coll.contacts[0].point;
                Vector2 myPos = transform.position;
                Vector2 direction = myPos - collisionPoint * KnockBackForce;

            rb2d.AddForce(direction * KnockBackForce);

            Speed -= 3;
            }
        }
    }