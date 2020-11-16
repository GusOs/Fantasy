﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestEnemyAttack : MonoBehaviour
{
    
    //Daño de ataque
    public int attackForest = 3;

    private Collider legsCollider;

    // Start is called before the first frame update
    void Start()
    {
        legsCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider legsCollider)
    {
        if (legsCollider.gameObject.CompareTag("Player"))
        {
            (legsCollider.gameObject.GetComponent("PlayerLife") as PlayerLife).currentHealth -= attackForest;
            GameManager.Instance.GameOver();
        }
    }
}
