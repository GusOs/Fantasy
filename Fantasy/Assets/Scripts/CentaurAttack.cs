using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentaurAttack : MonoBehaviour
{
    //Daño de ataque
    public float attackBoss = 5.0f;

    private Collider weaponCollider;

    // Start is called before the first frame update
    void Start()
    {
        weaponCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider weaponCollider)
    {
        if (weaponCollider.gameObject.CompareTag("Player"))
        {
            (weaponCollider.gameObject.GetComponent("PlayerMovement") as PlayerMovement).lifePlayer -= attackBoss;
        }
    }
}
