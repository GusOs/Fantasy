﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoAttackSound : MonoBehaviour
{
    public AudioSource audioSource;
    public Animator anim;
    public float stepDelay;
    public AudioClip defaultClip;
    private bool couroutineOn;

    void Start()
    {

        anim = this.gameObject.GetComponent<Animator>();

        couroutineOn = true;
        audioSource.clip = defaultClip;

        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {

        while (couroutineOn == true)
        {

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }

            yield return new WaitForSeconds(stepDelay);

        }
    }
}