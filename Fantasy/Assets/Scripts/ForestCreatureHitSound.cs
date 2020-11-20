using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestCreatureHitSound : MonoBehaviour
{
    public AudioSource audioSource;
    public Animator anim;
    public float stepDelay;
    public AudioClip defaultClip;
    private bool couroutineOn;

    private Collider legsCollider;

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

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2") && legsCollider.gameObject.CompareTag("Player"))
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
