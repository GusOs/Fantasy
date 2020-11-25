﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CentaurLife : MonoBehaviour
{
    //Vida del centauro
    public int maxHealth = 35;

    //Vida actual
    public int currentHealth;

    //Referencia al slider
    public Slider slider;

    // Referencia al Animator
    public Animator anim;

    UnityEngine.AI.NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentHealth;
        checkDead();
    }

    /*
     * Si la vida es menor o igual a 0 
     *  Reproduce animación de muerte y destruye el gameobject
     *  Si la animación de muerte se está reproduciendo, llama a la instancia de victoria
    */
    public void checkDead()
    {
        float timeDestroy = 1.6f;

        if (currentHealth <= 0)
        {
            anim.SetBool("death", true);
            Destroy(this.gameObject, timeDestroy);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("death"))
        {
            GameManager.Instance.WinGame();
        }
    }
}
