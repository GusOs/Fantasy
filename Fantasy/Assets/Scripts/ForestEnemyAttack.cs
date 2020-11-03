using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestEnemyAttack : MonoBehaviour
{
    
    //Daño de ataque
    public float attackForest = 5.0f;

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
        if (legsCollider.CompareTag("Player"))
        {
            //Audio
            (legsCollider.gameObject.GetComponent("PlayerMovement") as PlayerMovement).lifePlayer -= attackForest;
            // Check game state
            // check game over
        }
    }
}
