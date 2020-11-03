using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    private Collider enemyCollision;

    public Sound Hit;

    public float attackForce = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyCollision = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider enemyCollision)
    {
        if(enemyCollision.CompareTag("Enemy"))
        {
            //(enemyCollision.gameObject.GetComponent("PlayerMovement") as PlayerMovement).lifePlayer -= attackForce;
        }
    }

}
