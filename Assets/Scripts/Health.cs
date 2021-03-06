﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100;
    [SerializeField]
    private float actualHealth = 100;
    
    private GameManager gameManager;
   
    public GameObject monsterSpawner;

    public GameObject deathFX;

    void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void takeDamage(float damage)
    {
        actualHealth -= damage;
        actualHealth = Mathf.Clamp(actualHealth, 0, maxHealth);

        if (actualHealth <= 0)
        {
            Instantiate(deathFX, transform.position, Quaternion.identity);
            MonsterCountKill();
            Destroy(this.gameObject);
        }
    }

    public void MonsterCountKill(){
        switch (this.tag){
            case "Player":
            break;    
            default:
                monsterSpawner.GetComponent<Pathfinding.MonsterSpawner>().createMonster();
                gameManager.MonsterCountKill();
            break;
        }
    }

    public float getActualHealth(){
        return actualHealth;
    }
}
