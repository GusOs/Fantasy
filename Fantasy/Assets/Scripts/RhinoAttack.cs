using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoAttack : MonoBehaviour
{

    //Daño del ataque
    public float attackRhino = 5.0f;

    private Collider hornCollider;

    // Start is called before the first frame update
    void Start()
    {
        hornCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider hornCollider)
    {
        if (hornCollider.CompareTag("Player"))
        {
            //Audio
            (hornCollider.gameObject.GetComponent("PlayerMovement") as PlayerMovement).lifePlayer -= attackRhino;
            // Check game state
            // check game over
        }
    }
}
