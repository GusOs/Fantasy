using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ForestEnemyLife : MonoBehaviour
{
    // Vida del enemigo
    public int maxHealth = 20;

    //Vida actual
    public int currentHealth;

    // Referencia a la barra de vida
    public HealthBar healthBar;

    // Referencia al slider
    public Slider slider;

    // Referencia al item de vida
    public GameObject lifeItem;

    UnityEngine.AI.NavMeshAgent nav;

    //Animator del enemigo
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentHealth;
        CheckDeathForestCreature();
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    /*
     * Si la vida es igual o menor a 0
     * reproduce animación de muerte y para el nav
     * Si se reproduce la animación de muerte, instancia el item de vida y destruye el objeto del enemigo
    */
    public void CheckDeathForestCreature()
    {
        if (currentHealth <= 0)
        {
            anim.SetBool("death", true);
            nav = GetComponent<NavMeshAgent>();
            nav.isStopped = true;
        }
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            Instantiate(lifeItem, this.transform.position, Quaternion.LookRotation(this.transform.position));
            Destroy(gameObject);
        }
    }
}
