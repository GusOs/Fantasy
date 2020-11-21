using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public Animator anim;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentHealth;
        CheckDead();
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public void CheckDead()
    {
        if (currentHealth <= 0)
        {
            anim.SetBool("death", true);
        }
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
