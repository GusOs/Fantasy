using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Daño del ataque
    public int attackSword = 5;

    public Sound Hit;

    private Collider swordCollider;

    // Start is called before the first frame update
    void Start()
    {
        swordCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider swordCollider)
    {
        if (swordCollider.gameObject.CompareTag("Boss"))
        {
            (swordCollider.gameObject.GetComponent("CentaurLife") as CentaurLife).currentHealth -= attackSword;
            GameManager.Instance.GameOver();
        }
        else if(swordCollider.gameObject.CompareTag("Enemy"))
        {
            (swordCollider.gameObject.GetComponent("ForestEnemyLife") as ForestEnemyLife).currentHealth -= attackSword;
        }
        else if(swordCollider.gameObject.CompareTag("Enemy1"))
        {
            (swordCollider.gameObject.GetComponent("RhinoLife") as RhinoLife).currentHealth -= attackSword;
        }
    }
}
