using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CentaurLife : MonoBehaviour
{
    public int maxHealth = 35;
    public int currentHealth;

    public HealthBar healthBar;

    public Slider slider;

    public Animator anim;

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
        checkDead();
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public void checkDead()
    {
        float timeDestroy = 1.6f;

        if (currentHealth <= 0)
        {
            anim.SetBool("death", true);
            GameManager.Instance.WinGame();
            Destroy(this.gameObject, timeDestroy);
        }
    }
}
