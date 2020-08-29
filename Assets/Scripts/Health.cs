﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField]
    private float maxHealth = 100;
    [SerializeField]
    private float actualHealth = 100;

    public GameObject deathFX;

    //public SpriteRenderer healthBar;

    public void takeDamage(float damage)
    {
        actualHealth -= damage;
        actualHealth = Mathf.Clamp(actualHealth, 0, maxHealth);
        //healthBar.size = new Vector2(actualHealth / 100, 0.18f);

        if (actualHealth <= 0)
        {
            Instantiate(deathFX, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}