﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoFootsteps : MonoBehaviour
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

        StartCoroutine(Run());
    }

    IEnumerator Run()
    {

        while (couroutineOn == true)
        {

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
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
