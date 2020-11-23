using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class RhinoLife : MonoBehaviour
{
    // Vida del rhino
    public int maxHealth = 20;

    // Vida actual
    public int currentHealth;

    // Referencia a la barra de vida
    public HealthBar healthBar;

    // Referencia al slider
    public Slider slider;

    // Referencia al Animator
    public Animator anim;

    // Referencia al item de vida
    public GameObject lifeItem;

    UnityEngine.AI.NavMeshAgent nav;

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
        CheckDeathRhino();
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    /*
     * Si la vida del rino es igual o menor a 0
     * reproduce animación de muerte
     * Si esta se reproduce, instancia un item de vida y destruye el objeto del rino
     */
    public void CheckDeathRhino()
    {
        if (currentHealth <= 0)
        {
            anim.SetBool("death", true);
            nav = GetComponent<NavMeshAgent>();
            nav.isStopped = true;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            Instantiate(lifeItem, this.transform.position, Quaternion.LookRotation(this.transform.position));
            Destroy(gameObject);
        }
    }
}
