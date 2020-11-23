using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    // Vida del jugador
    public int maxHealth = 100;

    // Vida actual
    public int currentHealth;

    // Referencia a la barra de vida
    public HealthBar healthBar;

    // Referencia al Animator del jugador
    public Animator anim;

    // Referencia al slider
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

    /*
     * Si la vida del jugador es menor o igual a 0
     * Reproduce animación de muerte
     * Si esta se reproduce, llamar a la instancia de gameover
     */
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
