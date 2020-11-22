using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Daño del ataque
    public int attackSword = 5;

    public Sound Hit;

    private Collider swordCollider;

    public Animator anim;

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
