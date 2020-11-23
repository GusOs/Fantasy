using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSoundCentaur : MonoBehaviour
{
    //Variable del AudioSource
    public AudioSource audioSource;

    //Variable del animator
    public Animator anim;

    //Variable de delay
    public float stepDelay;

    //Variable del Audioclip
    public AudioClip defaultClip;

    //Variable para controlar la corrutina
    private bool couroutineOn;

    void Start()
    {

        anim = this.gameObject.GetComponent<Animator>();

        couroutineOn = true;
        audioSource.clip = defaultClip;

        StartCoroutine(Walking());
    }

    //Si la corrutina está activada, reproduce el sonido si la animación que se reproduce es la indicada
    IEnumerator Walking()
    {

        while (couroutineOn == true)
        {

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("thc4_arma|st_run"))
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
