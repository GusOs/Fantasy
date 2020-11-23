using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Daño del ataque
    public int attackSword = 5;

    // Sonido al atacar
    public Sound Hit;

    // Colisión del arma
    private Collider swordCollider;

    // Animator del jugador
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        swordCollider = GetComponent<Collider>();
    }

    // Si está atacando y el arma colisiona con algún enemigo
    private void OnTriggerEnter(Collider swordCollider)
    {
        if (swordCollider.gameObject.CompareTag("Boss") && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack3"))
        {
            (swordCollider.gameObject.GetComponent("CentaurLife") as CentaurLife).currentHealth -= attackSword;
            AudioManager.Instance.PlaySound(Hit);
        }
        else if(swordCollider.gameObject.CompareTag("Enemy") && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack3"))
        {
            (swordCollider.gameObject.GetComponent("ForestEnemyLife") as ForestEnemyLife).currentHealth -= attackSword;
            AudioManager.Instance.PlaySound(Hit);
        }
        else if(swordCollider.gameObject.CompareTag("Enemy1") && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack3"))
        {
            (swordCollider.gameObject.GetComponent("RhinoLife") as RhinoLife).currentHealth -= attackSword;
            AudioManager.Instance.PlaySound(Hit);
        }
    }
}
