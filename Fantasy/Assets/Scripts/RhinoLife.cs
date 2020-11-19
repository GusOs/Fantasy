using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class RhinoLife : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;

    public HealthBar healthBar;

    public Slider slider;

    public Animator anim;

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

    public void CheckDeathRhino()
    {
        if (currentHealth == 0)
        {
            anim.SetBool("death", true);
            nav = GetComponent<NavMeshAgent>();
            nav.isStopped = true;
            Destroy(this.gameObject);
            Instantiate(lifeItem, this.transform.position, Quaternion.LookRotation(this.transform.position));
        }
    }
}
