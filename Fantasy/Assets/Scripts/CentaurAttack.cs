using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentaurAttack : MonoBehaviour
{
    //Daño de ataque
    public int attackBoss = 5;

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
            (weaponCollider.gameObject.GetComponent("PlayerLife") as PlayerLife).currentHealth -= attackBoss;
        }
    }
}
