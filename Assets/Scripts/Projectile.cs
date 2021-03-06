﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public string collisionTag;
    public float speed;
    public int damage = 5;
    public GameObject hitEffect;
    private Vector2 moveDirection;
    private Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.right * Time.fixedDeltaTime * speed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        if(col.transform.tag == collisionTag)
        {
            col.gameObject.GetComponent<Health>().takeDamage(damage);
        }
        Destroy(gameObject);
    }
}
